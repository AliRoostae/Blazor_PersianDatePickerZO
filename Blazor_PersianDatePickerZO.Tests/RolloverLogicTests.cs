using Blazor_PersianDatePickerZO.Hellper;
using Xunit;

namespace Blazor_PersianDatePickerZO.Tests;

public class RolloverLogicTests
{
    [Fact]
    public void Hour_Exceeds23_RollsToNextDay()
    {
        var date = new DateTime(2024, 3, 20, 23, 30, 0);
        var result = date.AddHours(1); // شبیه‌سازی همون چیزی که Hours setter انجام می‌ده

        Assert.Equal(21, result.Day);
        Assert.Equal(0, result.Hour);
    }

    [Fact]
    public void Hour_BelowZero_RollsToPreviousDay()
    {
        var date = new DateTime(2024, 3, 20, 0, 0, 0);
        var result = date.AddHours(-1);

        Assert.Equal(19, result.Day);
        Assert.Equal(23, result.Hour);
    }

    [Fact]
    public void Minute_Exceeds59_RollsToNextHour()
    {
        var date = new DateTime(2024, 3, 20, 10, 59, 0);
        var result = date.AddMinutes(1);

        Assert.Equal(11, result.Hour);
        Assert.Equal(0, result.Minute);
    }

    [Fact]
    public void MonthRollover_EndOfEsfand_MovesToNextYear()
    {
        // آخرین روز اسفند ۱۴۰۲ + ۱ روز = اول فروردین ۱۴۰۳
        var lastDayOfYear = DatePickerZeroOneHellper.Persian.ToDateTime(1402, 12, 29, 0, 0, 0, 0);
        var next = lastDayOfYear.AddDays(1);

        Assert.Equal(1403, next.YearFa());
        Assert.Equal(1, next.MonthFa());
        Assert.Equal(1, next.DayFa());
    }
}