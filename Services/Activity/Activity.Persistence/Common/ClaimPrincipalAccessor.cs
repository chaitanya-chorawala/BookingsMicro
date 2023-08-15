using Activity.Common.Model;
using Activity.Core.Contract.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Activity.Persistence.Common;

public class ClaimPrincipalAccessor : IClaimPrincipalAccessor
{
    private readonly HttpContext? _httpContext;

    public ClaimPrincipalAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext;
    }
    public ClaimsPrincipal? ClaimsPrincipal => _httpContext?.User;

    public User User => SetUserInfo();
    public string AccessToken => _httpContext?.GetTokenAsync("access_token").GetAwaiter().GetResult() ?? "";

    private User SetUserInfo()
    {
        return new User()
        {
            Id = Convert.ToInt64(ClaimsPrincipal?.Claims?.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value),
            Name = ClaimsPrincipal?.Claims?.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault()?.Value,
            Email = ClaimsPrincipal?.Claims?.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value,            
            Role = ClaimsPrincipal?.Claims?.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault()?.Value,
        };
    }
}
