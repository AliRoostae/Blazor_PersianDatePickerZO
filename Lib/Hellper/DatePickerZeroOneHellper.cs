using System.Globalization;
using System.Text.RegularExpressions;

namespace Blazor_PersianDatePickerZO.Hellper
{
    internal static class DatePickerZeroOneHellper
    {
        public readonly static PersianCalendar Persian = new PersianCalendar();

        public static int YearFa(this DateTime argo) => Persian.GetYear(argo);
        public static int MonthFa(this DateTime argo) => Persian.GetMonth(argo);
        public static int DayFa(this DateTime argo) => Persian.GetDayOfMonth(argo);

        public static int DaysInMonth(this DateTime argo) => Persian.GetDaysInMonth(argo.YearFa(), argo.MonthFa(), PersianCalendar.PersianEra);

        public static int OneDayMonthDayWeek(this DateTime argo) => (int)Persian.ToDateTime(argo.YearFa(), argo.MonthFa(), 1, 0, 0, 0, 1, PersianCalendar.PersianEra).DayOfWeek;

        internal static readonly string[] MonthFaName = { "", "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        internal static readonly string[] NmeDayPersian =
         {
          "",  "اول" ,"دوم" , "سوم"  , "چهارم"  , "پنجم"  , "ششم"  , "هفتم"  , "هشتم"  , "نهم"  , "دهم"
            , "یازدهم"  , "دوازدهم"  , "سیزدهم"  , "چهاردهم"  , "پانزدهم"  , "شانزدهم"  , "هفدهم"  , "هجدهم"  , "نوزدهم"  , "بیستم"
            , "بیست و یکم"  , "بیست و دوم" , "بیست و سوم" , "بیست و چهارم" , "بیست و پنجم" , "بیست و ششم" , "بیست و هفتم", "بیست و هشتم" , "بیست و نهم" , "سی ام" , "سی و یکم"
        };

        /// <summary>
        /// Converts the day of the week to Persian.
        /// </summary>
        public static string WeekDayPersian(this DateTime argo) => argo.DayOfWeek switch
        {
            DayOfWeek.Sunday => "یک شنبه",
            DayOfWeek.Monday => "دو شنبه",
            DayOfWeek.Tuesday => "سه شنبه",
            DayOfWeek.Wednesday => "چهار شنبه",
            DayOfWeek.Thursday => "پنج شنبه",
            DayOfWeek.Friday => "جمعه",
            DayOfWeek.Saturday => "شنبه",
            _ => "خطا",
        };
        // با Regex  فقط روی ‌ ‌  

        private static readonly Regex TokenRegex = new(@"yyyy|yy|MMM|MM|M|ddd|dd|d|D|hh|mm|ss", RegexOptions.Compiled);

        public static string FormatDate(this DateTime date, string format)
        {
            return TokenRegex.Replace(format, m => m.Value switch
            {
                "yyyy" => date.YearFa().ToString("D4"),
                "yy" => date.YearFa().ToString("D2"),
                "MMM" => MonthFaName[date.MonthFa()],
                "MM" => date.MonthFa().ToString("D2"),
                "M" => date.MonthFa().ToString(),
                "ddd" => date.WeekDayPersian(),
                "dd" => date.DayFa().ToString("D2"),
                "d" => date.DayFa().ToString(),
                "D" => NmeDayPersian[date.DayFa()],
                "hh" => date.Hour.ToString("D2"),
                "mm" => date.Minute.ToString("D2"),
                "ss" => date.Second.ToString("D2"),
                _ => m.Value
            });
        }

        public static bool ShowTimeZoDP(this string format) =>
            !string.IsNullOrEmpty(format) &&
            format.Contains("ss") &&
            format.Contains("mm") &&
            format.Contains("hh");



    }



}
