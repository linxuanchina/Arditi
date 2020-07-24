using FluentValidation;

namespace Toxic.Validation
{
    /// <summary>
    /// 规则对象扩展
    /// </summary>
    public static class RuleBuilderExtensions
    {
        /// <summary>
        /// 验证中文
        /// </summary>
        public static IRuleBuilderOptions<T, string> Chinese<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new Validators.ChineseValidator());
        }

        /// <summary>
        /// 验证身份证号码
        /// </summary>
        public static IRuleBuilderOptions<T, string> IdCardNo<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new Validators.IdCardNoValidator());
        }

        /// <summary>
        /// 验证手机号码
        /// </summary>
        public static IRuleBuilderOptions<T, string> PhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new Validators.PhoneNumberValidator());
        }

        /// <summary>
        /// 验证车牌号
        /// </summary>
        public static IRuleBuilderOptions<T, string> PlateNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new Validators.PlateNumberValidator());
        }

        /// <summary>
        /// 验证邮政编码
        /// </summary>
        public static IRuleBuilderOptions<T, string> PostalCode<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new Validators.PostalCodeValidator());
        }
    }
}