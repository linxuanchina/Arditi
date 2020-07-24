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
            if (context.PropertyValue.IsNotNull() && context.PropertyValue is string stringValue &&
                stringValue.IsNotNullOrEmpty())
                return stringValue.IsMatch(@"^[\u4e00-\u9fa5]+$");
            return true;
        }
    }
}