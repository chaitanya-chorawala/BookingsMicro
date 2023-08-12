using Identity.API.Data;
using Identity.API.Data.Entity;
using Identity.API.Dto;
using Identity.API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IRefreshTokenGenerator _tokenGenerator;
    private readonly IConfiguration _configuration;
    private readonly string _validAudience;
    private readonly string _validIssuer;
    private readonly string _secretKey;

    public AuthController(
        ApplicationDbContext context,
        IRefreshTokenGenerator tokenGenerator,
        IConfiguration configuration)
    {
        _context = context;
        _tokenGenerator = tokenGenerator;
        _configuration = configuration;
        _validAudience = _configuration["JWT:ValidAudience"]!;
        _validIssuer = _configuration["JWT:ValidIssuer"]!;
        _secretKey = _configuration["JWT:Secret"]!;
    }

    private async Task<LoginResponseDto> GenerateToken(User user)
    {
        LoginResponseDto response = new LoginResponseDto();
        //Generate token
        var tokenHandler = new JwtSecurityTokenHandler();
        var secretBytes = Encoding.UTF8.GetBytes(_secretKey);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }
            ),
            Audience = _validAudience,
            Issuer = _validIssuer,
            NotBefore = DateTime.Now,
            Expires = DateTime.Now.AddMinutes(15),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretBytes), SecurityAlgorithms.HmacSha256)
        };

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var accessToken = tokenHandler.WriteToken(securityToken);

        //Building response model
        string refreshToken = await _tokenGenerator.GenerateRefreshToken(user.Name);
        response.AccessToken = accessToken;
        response.RefreshToken = refreshToken;

        return response;
    }


    private async Task<LoginResponseDto> RegenerateToken(string username, Claim[] claims)
    {
        LoginResponseDto tokenResponse = new LoginResponseDto();
        var tokenkey = Encoding.UTF8.GetBytes(_secretKey);
        var tokenhandler = new JwtSecurityToken(
            claims: claims,
            audience: _validAudience,
            issuer: _validIssuer,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddMinutes(15),
             signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)

            );
        tokenResponse.AccessToken = new JwtSecurityTokenHandler().WriteToken(tokenhandler);
        tokenResponse.RefreshToken = await _tokenGenerator.GenerateRefreshToken(username);

        return tokenResponse;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        //Check user is exists
        var user = await _context.User.FirstOrDefaultAsync(x => x.IsActive
            && string.Equals(x.Name, model.Username)
            && string.Equals(x.Password, model.Password));
        if (user == null)
            return Unauthorized();

        LoginResponseDto response = await GenerateToken(user);
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        //Check user is exists
        var user = await _context.User.FirstOrDefaultAsync(x => x.IsActive
            && string.Equals(x.Name, model.Name)
            && string.Equals(x.Password, model.Password));
        if (user == null)
        {
            user = new User()
            {
                UserId = Guid.NewGuid().ToString(),
                Name = model.Name,
                Password = model.Password,
                Email = model.Email,
                IsActive = true,
                Role = Roles.USER.ToString()
            };
            _context.User.Add(user);
        }
        else
        {
            user.Email = model.Email;
            user.IsActive = true;
        }
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] LoginResponseDto model)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(model.AccessToken);
        var username = securityToken.Claims.FirstOrDefault(x => x.Type == "unique_name")?.Value;

        var reference = await _context.RefreshToken.FirstOrDefaultAsync(x => x.Username == username
            && x.Token == model.RefreshToken);
        if (reference == null)
            return Unauthorized();

        LoginResponseDto response = await RegenerateToken(username!, securityToken.Claims.ToArray());
        return Ok(response);
    }
}
