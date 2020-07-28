using System.Text.RegularExpressions;
using FluentValidation.Resources;
using FluentValidation.Validators;

namespace Toxic.Validation.Validators
{
    /// <summary>
    /// 身份证号码验证器
    /// </summary>
    public sealed class IdCardNoValidator : PropertyValidator
    {
        public IdCardNoValidator() : base(new LanguageStringSource(nameof(IdCardNoValidator)))
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue != null && context.PropertyValue is string stringValue &&
                !string.IsNullOrEmpty(stringValue))
                return Regex.IsMatch(stringValue,
                    @"^(^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$)|(^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[Xx])$)$");
            return true;
        }
    }
}