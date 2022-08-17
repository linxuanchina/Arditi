using System.Text.RegularExpressions;
using Arditi.Application;

namespace FluentValidation;

public static class RuleBuilderExtensions
{
    public static IRuleBuilder<T, Pagination> SetPaginationValidator<T>(this IRuleBuilder<T, Pagination> builder) =>
        builder.SetValidator(new PaginationValidator());

    public static IRuleBuilderOptions<T, string?> PhoneNumber<T>(this IRuleBuilder<T, string?> builder) =>
        builder.Matches(@"^(0|86|17951)?(13[0-9]|15[012356789]|166|17[3678]|18[0-9]|14[57])[0-9]{8}$",
            RegexOptions.Singleline);

    public static IRuleBuilderOptions<T, string?> PostalCode<T>(this IRuleBuilder<T, string?> builder) =>
        builder.Matches(@"^[1-9]\d{5}(?!\d)$", RegexOptions.Singleline);

    public static IRuleBuilderOptions<T, string?> PlateNumber<T>(this IRuleBuilder<T, string?> builder) =>
        builder.Matches(@"^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-Z0-9]{4}[A-Z0-9挂学警港澳]{1}$",
            RegexOptions.Singleline);
}
