using Microsoft.EntityFrameworkCore;
using Identity.API.Data;
using Identity.API.Data.Entity;
using System.Security.Cryptography;

namespace Identity.API.Helper;

public class RefreshTokenGenerator : IRefreshTokenGenerator
{
    private readonly ApplicationDbContext _context;

    public RefreshTokenGenerator(ApplicationDbContext context)
    {
        _context=context;
    }
    public async Task<string> GenerateRefreshToken(string username)
    {
        //Generate refresh token based on random numbers bytes
        var randomNumber = new Byte[32];
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(randomNumber);
        string refreshToken = Convert.ToBase64String(randomNumber);

        var userToken = await _context.RefreshToken.FirstOrDefaultAsync(x => x.Username == username);
        //If usertoken not exists create new entry
        if (userToken == null)
        {
            userToken = new UserRefreshToken()
            {
                Username = username,
                Token = refreshToken
            };
            _context.RefreshToken.Add(userToken);
        }
        //If exists update refresh token
        else
        {
            userToken.Token = refreshToken;
        }

        //Save inser or update change
        await _context.SaveChangesAsync();

        return refreshToken;
    }
}
