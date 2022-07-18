using System.Text.RegularExpressions;

namespace FluentValidation;

public static class RuleBuilderExtensions
{
    public static IRuleBuilder<T, string> PhoneNumber<T>(this IRuleBuilder<T, string> builder) =>
        builder.Matches(@"^(13[0-9]|14[5|7]|15[0-9]|18[0-9]|19[4|5])\d{8}$", RegexOptions.Singleline);

    public static IRuleBuilder<T, string> PostalCode<T>(this IRuleBuilder<T, string> builder) =>
        builder.Matches(@"^\d{6}$", RegexOptions.Singleline);

    public static IRuleBuilder<T, string> PlateNumber<T>(this IRuleBuilder<T, string> builder) =>
        builder.Matches(@"^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-Z0-9]{4}[A-Z0-9挂学警港澳]{1}$",
            RegexOptions.Singleline);
}
