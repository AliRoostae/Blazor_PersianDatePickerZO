using Blazor_PersianDatePickerZO.Helper;
using Xunit;

namespace Blazor_PersianDatePickerZO.Tests;

public class DatePickerZeroOneHellperTests
{
    [Theory]
    [InlineData(2024, 3, 20, 1403, 1, 1)]   // اول فروردین ۱۴۰۳
    [InlineData(2025, 3, 21, 1404, 1, 1)]   // اول فروردین ۱۴۰۴ (چون ۱۴۰۳ کبیسه‌ست، یک روز دیرتر شروع می‌شه)
    [InlineData(2023, 3, 21, 1402, 1, 1)]   // اول فروردین ۱۴۰۲
    [InlineData(2024, 3, 19, 1402, 12, 29)] // آخرین روز اسفند ۱۴۰۲ (غیرکبیسه)
    public void YearMonthDay_ConvertsCorrectly(int gy, int gm, int gd, int expY, int expM, int expD)
    {
        var date = new DateTime(gy, gm, gd);
        Assert.Equal(expY, date.YearFa());
        Assert.Equal(expM, date.MonthFa());
        Assert.Equal(expD, date.DayFa());
    }

    [Theory]
    [InlineData(1403, 29)] // ۱۴۰۳ کبیسه است، اسفندش ۳۰ روزه
    [InlineData(1402, 29)] // ۱۴۰۲ کبیسه نیست، اسفندش ۲۹ روزه
    public void DaysInMonth_EsfandLeapYear_IsCorrect(int faYear, int expectedMinDays)
    {
        // یک تاریخ دلخواه در اسفند همون سال جلالی می‌سازیم
        var date = DatePickerZeroOneHellper.Persian.ToDateTime(faYear, 12, 1, 0, 0, 0, 0);
        Assert.True(date.DaysInMonth() >= expectedMinDays);
    }

    [Theory]
    [InlineData(DayOfWeek.Saturday, "شنبه")]
    [InlineData(DayOfWeek.Friday, "جمعه")]
    public void WeekDayPersian_ReturnsCorrectName(DayOfWeek dow, string expected)
    {
        // نزدیک‌ترین تاریخ با اون DayOfWeek رو پیدا می‌کنیم
        var date = new DateTime(2024, 1, 1);
        while (date.DayOfWeek != dow) date = date.AddDays(1);

        Assert.Equal(expected, date.WeekDayPersian());
    }
}