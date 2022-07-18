namespace Arditi.Security;

public static class PasswordEncoder
{
    public static string Encode(string rawPassword) =>
        BCrypt.Net.BCrypt.HashPassword(Check.NotEmpty(rawPassword, nameof(rawPassword)));

    public static bool Matches(string rawPassword, string encodedPassword) => BCrypt.Net.BCrypt.Verify(
        Check.NotEmpty(rawPassword, nameof(rawPassword)),
        Check.NotEmpty(encodedPassword, nameof(encodedPassword)));
}
