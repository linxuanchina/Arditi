using System.Text.RegularExpressions;
using FluentValidation.Resources;
using FluentValidation.Validators;

namespace Toxic.Validation.Validators
{
    /// <summary>
    /// 邮政编码验证器
    /// </summary>
    public sealed class PostalCodeValidator : PropertyValidator
    {
        public PostalCodeValidator() : base(new LanguageStringSource(nameof(PostalCodeValidator)))
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue != null && context.PropertyValue is string stringValue &&
                !string.IsNullOrEmpty(stringValue))
                return Regex.IsMatch(stringValue,
                    @"^[1-9]\d{5}(?!\d)$");
            return true;
        }
    }
}