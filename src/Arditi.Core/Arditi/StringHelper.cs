namespace Arditi;

public static class StringHelper
{
    public static bool Compare(string left, string right, bool ignoreCase = false)
    {
        var comparison = StringComparison.Ordinal;

        if (ignoreCase)
        {
            comparison = StringComparison.OrdinalIgnoreCase;
        }

        return string.Compare(left, right, comparison) == 0;
    }

    public static string? SafeTrim(string? str) => string.IsNullOrEmpty(str) ? str : str.Trim();
}
