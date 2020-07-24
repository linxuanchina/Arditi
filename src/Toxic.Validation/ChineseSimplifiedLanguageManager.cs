using FluentValidation.Resources;
using Toxic.Validation.Validators;

namespace Toxic.Validation
{
    /// <summary>
    /// 多语言管理器（简体中文）
    /// </summary>
    public class ChineseSimplifiedLanguageManager : LanguageManager
    {
        public ChineseSimplifiedLanguageManager()
        {
            AddTranslation("zh-CN", nameof(ChineseValidator), "'{PropertyName}' 必须使用中文。");
            AddTranslation("zh-CN", nameof(PostalCodeValidator), "'{PropertyName}' 不是有效的邮政编码。");
            AddTranslation("zh-CN", nameof(PhoneNumberValidator), "'{PropertyName}' 不是有效的手机号码。");
            AddTranslation("zh-CN", nameof(PlateNumberValidator), "'{PropertyName}' 不是有效的车牌号。");
            AddTranslation("zh-CN", nameof(IdCardNoValidator), "'{PropertyName}' 不是有效的身份证号码。");
        }
    }
}