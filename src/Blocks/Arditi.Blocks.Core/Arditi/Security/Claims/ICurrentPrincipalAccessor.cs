using System.Security.Claims;

namespace Arditi.Security.Claims;

public interface ICurrentPrincipalAccessor
{
    ClaimsPrincipal? Principal { get; }
}
