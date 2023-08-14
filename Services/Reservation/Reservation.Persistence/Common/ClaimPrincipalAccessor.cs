using Reservation.Common.Model;
using Reservation.Core.Contract.Common;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Security.Claims;

namespace Reservation.Persistence.Common;

public class ClaimPrincipalAccessor : IClaimPrincipalAccessor
{
    private readonly HttpContext? _httpContext;

    public ClaimPrincipalAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext;
    }
    public ClaimsPrincipal? ClaimsPrincipal => _httpContext?.User;

    public User User => SetUserInfo();

    private User SetUserInfo()
    {
        return new User()
        {
            Id = ClaimsPrincipal?.Claims?.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value,
            Name = ClaimsPrincipal?.Claims?.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault()?.Value,
            Email = ClaimsPrincipal?.Claims?.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value,            
            Role = ClaimsPrincipal?.Claims?.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault()?.Value,
        };
    }
}
