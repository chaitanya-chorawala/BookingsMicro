using Activity.Common.Model;
using System.Security.Claims;

namespace Activity.Core.Contract.Common;

public interface IClaimPrincipalAccessor
{
    ClaimsPrincipal? ClaimsPrincipal { get; }
    User User { get; }
    string AccessToken { get; }
}
