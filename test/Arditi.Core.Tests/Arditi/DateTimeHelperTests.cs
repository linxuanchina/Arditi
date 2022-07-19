using Shouldly;

namespace Arditi;

public class DateTimeHelperTests
{
    [Fact]
    public void EpochTimeTest()
    {
        var dateTime = new DateTime(1991, 10, 9, 18, 31, 56, 333);
        var epochTime = EpochTimeHelper.DateTimeToEpochTime(dateTime);
        epochTime.ShouldBe(687004316);
        var dateTimeFromEpochTime = EpochTimeHelper.EpochTimeToDateTime(epochTime);
        dateTimeFromEpochTime.Year.ShouldBe(dateTime.Year);
        dateTimeFromEpochTime.Month.ShouldBe(dateTime.Month);
        dateTimeFromEpochTime.Day.ShouldBe(dateTime.Day);
        dateTimeFromEpochTime.Hour.ShouldBe(dateTime.Hour);
        dateTimeFromEpochTime.Minute.ShouldBe(dateTime.Minute);
        dateTimeFromEpochTime.Second.ShouldBe(dateTime.Second);
        var longEpochTime = EpochTimeHelper.DateTimeToLongEpochTime(dateTime);
        longEpochTime.ShouldBe(687004316333);
        var dateTimeFromLongEpochTime = EpochTimeHelper.LongEpochTimeToDateTime(longEpochTime);
        dateTimeFromLongEpochTime.Year.ShouldBe(dateTime.Year);
        dateTimeFromLongEpochTime.Month.ShouldBe(dateTime.Month);
        dateTimeFromLongEpochTime.Day.ShouldBe(dateTime.Day);
        dateTimeFromLongEpochTime.Hour.ShouldBe(dateTime.Hour);
        dateTimeFromLongEpochTime.Minute.ShouldBe(dateTime.Minute);
        dateTimeFromLongEpochTime.Second.ShouldBe(dateTime.Second);
        dateTimeFromLongEpochTime.Millisecond.ShouldBe(dateTime.Millisecond);
    }
}
