using System.Text.RegularExpressions;
using FluentValidation.Resources;
using FluentValidation.Validators;

namespace Toxic.Validation.Validators
{
    /// <summary>
    /// 手机号码验证器
    /// </summary>
    public sealed class PhoneNumberValidator : PropertyValidator
    {
        public PhoneNumberValidator() : base(new LanguageStringSource(nameof(PhoneNumberValidator)))
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue != null && context.PropertyValue is string stringValue &&
                !string.IsNullOrEmpty(stringValue))
                return Regex.IsMatch(stringValue,
                    @"^(0|86|17951)?(13[0-9]|15[012356789]|166|17[3678]|18[0-9]|14[57])[0-9]{8}$");
            return true;
        }
    }
}