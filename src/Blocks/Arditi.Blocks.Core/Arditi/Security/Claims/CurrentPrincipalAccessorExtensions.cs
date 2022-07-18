using System.Security.Claims;

namespace Arditi.Security.Claims;

public static class CurrentPrincipalAccessorExtensions
{
    public static Claim? FindClaim(this ICurrentPrincipalAccessor principalAccessor, string claimType) =>
        principalAccessor.Principal?.FindFirst(claim => StringHelper.Compare(claim.Type, claimType));

    public static Claim[]? FindClaims(this ICurrentPrincipalAccessor principalAccessor, string claimType) =>
        principalAccessor.Principal?.Claims
            .Where(claim => StringHelper.Compare(claim.Type, claimType))
            .ToArray() ?? null;

    public static string? FindClaimValue(this ICurrentPrincipalAccessor principalAccessor, string claimType) =>
        principalAccessor.FindClaim(claimType)?.Value;

    public static string[]? FindClaimArrayValue(this ICurrentPrincipalAccessor principalAccessor, string claimType) =>
        FindClaimValue(principalAccessor, claimType)?.Split(",", StringSplitOptions.RemoveEmptyEntries);

    public static int? FindClaimInt32Value(this ICurrentPrincipalAccessor principalAccessor, string claimType) =>
        FindClaimValue(principalAccessor, claimType)?.ToNullableInt32();

    public static long? FindClaimInt64Value(this ICurrentPrincipalAccessor principalAccessor, string claimType) =>
        FindClaimValue(principalAccessor, claimType)?.ToNullableInt64();

    public static bool? FindClaimBooleanValue(this ICurrentPrincipalAccessor principalAccessor, string claimType) =>
        FindClaimValue(principalAccessor, claimType)?.ToNullableBoolean();

    public static DateTime? FindClaimDateTimeValue(this ICurrentPrincipalAccessor principalAccessor, string claimType)
    {
        var longEpochTime = FindClaimInt64Value(principalAccessor, claimType);
        return longEpochTime.HasValue ? EpochTimeHelper.LongEpochTimeToDateTime(longEpochTime.Value) : null;
    }
}
