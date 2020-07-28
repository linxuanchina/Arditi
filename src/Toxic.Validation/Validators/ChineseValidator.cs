using System.Text.RegularExpressions;
using FluentValidation.Resources;
using FluentValidation.Validators;

namespace Toxic.Validation.Validators
{
    /// <summary>
    /// 中文验证器
    /// </summary>
    public sealed class ChineseValidator : PropertyValidator
    {
        public ChineseValidator() : base(new LanguageStringSource(nameof(ChineseValidator)))
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue != null && context.PropertyValue is string stringValue &&
                !string.IsNullOrEmpty(stringValue))
                return Regex.IsMatch(stringValue, @"^[\u4e00-\u9fa5]+$");
            return true;
        }
    }
}