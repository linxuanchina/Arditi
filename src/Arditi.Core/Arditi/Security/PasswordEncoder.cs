namespace Arditi.Security;

public static class PasswordEncoder
{
    public static string Encode(string rawPassword) =>
        BCrypt.Net.BCrypt.HashPassword(ExceptionHelper.NotEmpty(rawPassword, nameof(rawPassword)));

    public static bool Matches(string rawPassword, string encodedPassword) => BCrypt.Net.BCrypt.Verify(
        ExceptionHelper.NotEmpty(rawPassword, nameof(rawPassword)),
        ExceptionHelper.NotEmpty(encodedPassword, nameof(encodedPassword)));
}
