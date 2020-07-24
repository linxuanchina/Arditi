using System;

namespace Toxic.Core
{
    /// <summary>
    /// 格式化相关操作
    /// </summary>
    public static class Stylization
    {
        public static string FormatGuid(Guid source)
        {
            return source.ToString("N");
        }

        public static string FormatMoney(decimal source)
        {
            return $"{source:N2}";
        }
    }
}