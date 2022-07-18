using Epoch.net;

namespace Arditi;

public static class EpochTimeHelper
{
    public static long DateTimeToLongEpochTime(DateTime dateTime) => new LongEpochTime(dateTime).Epoch;

    public static int DateTimeToEpochTime(DateTime dateTime) => new EpochTime(dateTime).Epoch;

    public static DateTime LongEpochTimeToDateTime(long longEpochTime, bool toLocalTime = true)
    {
        var utc = new LongEpochTime(longEpochTime).DateTime;
        return toLocalTime ? utc.ToLocalTime() : utc;
    }

    public static DateTime EpochTimeToDateTime(int epochTime, bool toLocalTime = true)
    {
        var utc = new EpochTime(epochTime).DateTime;
        return toLocalTime ? utc.ToLocalTime() : utc;
    }
}
