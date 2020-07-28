using System.Text.RegularExpressions;
using FluentValidation.Resources;
using FluentValidation.Validators;

namespace Toxic.Validation.Validators
{
    /// <summary>
    /// 车牌号验证器
    /// </summary>
    public sealed class PlateNumberValidator : PropertyValidator
    {
        public PlateNumberValidator() : base(new LanguageStringSource(nameof(PlateNumberValidator)))
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue != null && context.PropertyValue is string stringValue &&
                !string.IsNullOrEmpty(stringValue))
                return Regex.IsMatch(stringValue,
                    @"^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-Z0-9]{4}[A-Z0-9挂学警港澳]{1}$");
            return true;
        }
    }
}