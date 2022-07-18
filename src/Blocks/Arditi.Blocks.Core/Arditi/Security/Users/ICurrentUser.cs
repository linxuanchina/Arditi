namespace Arditi.Security.Users;

public interface ICurrentUser
{
    bool IsAuthenticated { get; }
    int? UserId { get; }
}
