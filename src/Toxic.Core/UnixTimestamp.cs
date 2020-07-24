using System;

namespace Toxic.Core
{
    /// <summary>
    /// Unix时间戳相关操作
    /// </summary>
    public static class UnixTimestamp
    {
        /// <summary>
        /// 纪元时间
        /// </summary>
        private static readonly DateTime EpochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        
        /// <summary>
        /// 将DateTime对象转换成Unix时间戳
        /// </summary>
        public static long ConvertToTimeStamp(DateTime dateTime)
        {
            var utcDateTime = dateTime;
            if (dateTime.Kind != DateTimeKind.Utc)
            {
                utcDateTime = dateTime.ConvertTimeToUtc(TimeZoneInfo.Local);
            }
            return utcDateTime.Subtract(EpochTime).TotalMilliseconds.ToInt64();
        }

        /// <summary>
        /// 将Unix时间戳转换成DateTime对象
        /// </summary>
        public static DateTime ConvertToDateTime(long timeStamp)
        {
            return EpochTime.AddMilliseconds(timeStamp).ToLocalTime();
        }
    }
}