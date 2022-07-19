namespace Arditi;

public static class GuidHelper
{
    public static string Format(Guid guid, bool ignoreEmpty = false)
    {
        if (!ignoreEmpty)
        {
            Check.NotEmpty(guid, nameof(guid));
        }

        return $"{guid:N}";
    }

    public static bool Compare(Guid left, Guid right, bool ignoreEmpty = false)
    {
        if (!ignoreEmpty)
        {
            return Check.NotEmpty(left, nameof(left)) == Check.NotEmpty(right, nameof(right));
        }

        return left == right;
    }
}
