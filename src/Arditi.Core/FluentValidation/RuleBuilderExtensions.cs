using System.Text.RegularExpressions;
using Arditi.Application;

namespace FluentValidation;

public static class RuleBuilderExtensions
{
    public static IRuleBuilder<T, Pagination> SetPaginationValidator<T>(this IRuleBuilder<T, Pagination> builder) =>
        builder.SetValidator(new PaginationValidator());

    public static IRuleBuilder<T, string> PhoneNumber<T>(this IRuleBuilder<T, string> builder) =>
        builder.Matches(@"^(13[0-9]|14[5|7]|15[0-9]|18[0-9]|19[4|5])\d{8}$", RegexOptions.Singleline);

    public static IRuleBuilder<T, string> PostalCode<T>(this IRuleBuilder<T, string> builder) =>
        builder.Matches(@"^\d{6}$", RegexOptions.Singleline);
}
