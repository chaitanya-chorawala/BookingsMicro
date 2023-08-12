using Hotel.Common.Model;
using System.Security.Claims;

namespace Hotel.Core.Contract.Common;

public interface IClaimPrincipalAccessor
{
    ClaimsPrincipal? ClaimsPrincipal { get; }
    User User { get; }
}
