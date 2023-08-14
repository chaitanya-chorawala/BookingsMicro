using Reservation.Common.Model;
using System.Security.Claims;

namespace Reservation.Core.Contract.Common;

public interface IClaimPrincipalAccessor
{
    ClaimsPrincipal? ClaimsPrincipal { get; }
    User User { get; }
}
