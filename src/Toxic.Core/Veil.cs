namespace Toxic.Core
{
    /// <summary>
    /// 隐式相关操作
    /// </summary>
    public static class Veil
    {
        public static string VeiledPhoneNum(string source)
        {
            return source.IsNotNullOrEmpty() ? source : source.Remove(3, 6).Insert(3, "******");
        }

        public static string VeiledPlateNumber(string source)
        {
            return string.IsNullOrWhiteSpace(source)
                ? source
                : $"{source.Substring(0, 2)}***{source.Substring(source.Length - 2, 2)}";
        }

        public static string VeiledVin(string source)
        {
            return string.IsNullOrWhiteSpace(source)
                ? source
                : $"{source.Substring(0, 3)}***********{source.Substring(source.Length - 3, 3)}";
        }

        public static string VeiledMoney(decimal source)
        {
            return "*";
        }
    }
}