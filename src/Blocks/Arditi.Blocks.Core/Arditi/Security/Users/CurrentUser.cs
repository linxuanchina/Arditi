using Arditi.Security.Claims;

namespace Arditi.Security.Users;

public sealed class CurrentUser : ICurrentUser
{
    private readonly ICurrentPrincipalAccessor _principalAccessor;

    public CurrentUser(ICurrentPrincipalAccessor principalAccessor)
    {
        _principalAccessor = principalAccessor;
    }

    public bool IsAuthenticated => UserId.HasValue;
    public int? UserId => _principalAccessor.FindClaimInt32Value(ArditiClaimTypes.UserId);
}
