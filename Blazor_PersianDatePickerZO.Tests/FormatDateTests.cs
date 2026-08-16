using Blazor_PersianDatePickerZO.Hellper;
using Xunit;

namespace Blazor_PersianDatePickerZO.Tests;

public class FormatDateTests
{
    [Fact]
    public void FormatDate_YearMonthDay_FormatsCorrectly()
    {
        var date = new DateTime(2024, 3, 20); // اول فروردین ۱۴۰۳
        var result = date.FormatDate("yyyy/MM/dd");
        Assert.Equal("1403/01/01", result);
    }

    [Fact]
    public void FormatDate_MonthName_UsesFarsiName()
    {
        var date = new DateTime(2024, 3, 20);
        var result = date.FormatDate("MMM");
        Assert.Equal("فروردین", result);
    }

    [Fact]
    public void FormatDate_TimeTokens_FormatCorrectly()
    {
        var date = new DateTime(2024, 3, 20, 21, 5, 9);
        var result = date.FormatDate("hh:mm:ss");
        Assert.Equal("21:05:09", result);
    }

    [Fact]
    public void FormatDate_LiteralTextWithConflictingLetters_IsPreserved()
    {
        // یک سناریوی واقعی: بررسی می‌کنیم که خروجی جایگزینی یک توکن،
        // دوباره توسط توکن‌های بعدی در زنجیره اسکن نشه
        var date = new DateTime(2024, 3, 20); // ۱۴۰۳/۰۱/۰۱
        var result = date.FormatDate("D ddd");
        // "D" -> "اول" (نهم روز نیست، این اول فروردینه، پس day=1 -> "اول")
        Assert.StartsWith("اول", result);
    }

    [Theory]
    [InlineData("hh:mm:ss", true)]
    [InlineData("yyyy/MM/dd", false)]
    [InlineData("hh:mm", false)] // ss نداره، نباید true بشه
    public void ShowTimeZoDP_DetectsTimeFormat(string format, bool expected)
    {
        Assert.Equal(expected, format.ShowTimeZoDP());
    }
}