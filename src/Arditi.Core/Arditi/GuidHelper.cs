namespace Arditi;

public static class GuidHelper
{
    public static string Format(Guid guid, bool ignoreEmpty = false)
    {
        if (!ignoreEmpty)
        {
            ExceptionHelper.NotEmpty(guid, nameof(guid));
        }

        return $"{guid:N}";
    }

    public static bool Compare(Guid left, Guid right, bool ignoreEmpty = false)
    {
        if (!ignoreEmpty)
        {
            return ExceptionHelper.NotEmpty(left, nameof(left)) == ExceptionHelper.NotEmpty(right, nameof(right));
        }

        return left == right;
    }
}
