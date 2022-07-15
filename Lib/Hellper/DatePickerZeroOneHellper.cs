using System.Globalization;

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

      internal static  string[] MonthFaName => new[] 
      { "", "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذز", "دی", "بهمن", "اسفند" };
      internal static  string[] NmeDayPersian =>new[]
       {
          "",  "اول" ,"دوم" , "سوم"  , "چهارم"  , "پنجم"  , "ششم"  , "هفتم"  , "هشتم"  , "نهم"  , "دهم"
            , "یازدهم"  , "دوازدهم"  , "سیزدهم"  , "چهاردهم"  , "پانزدهم"  , "شانزدهم"  , "هفدهم"  , "هجدهم"  , "نوزدهم"  , "بیستم"
            , "بیست و یکم"  , "بیست و دوم" , "بیست و سوم" , "بیست و چهارم" , "بیست و پنجم" , "بیست و ششم" , "بیست و هفتم", "بیست و هشتم" , "بیست و نهم" , "سی ام" , "سی و یکم"
        };

        public static string WeekDayPersian(this DateTime argo)
        {
            switch (argo.DayOfWeek)
            {
                case DayOfWeek.Sunday:    return "یک شنبه";
                case DayOfWeek.Monday:    return "دو شنبه";
                case DayOfWeek.Tuesday:   return "سه شنبه";
                case DayOfWeek.Wednesday: return "چهار شنبه";
                case DayOfWeek.Thursday:  return "پنج شنبه";
                case DayOfWeek.Friday:    return "جمعه";
                case DayOfWeek.Saturday:  return "شنبه";
                default: return "خطا";
            }
        }
        public static string FormatDate(this DateTime date,string format)
        {
            return format.Replace("Y", "y")
                          .Replace("yyyy", date.YearFa().ToString("D4"))
                          .Replace("yy", date.YearFa().ToString("D2"))
                          .Replace("MMM", MonthFaName[date.MonthFa()])
                          .Replace("MM", date.MonthFa().ToString("D2"))
                          .Replace("M", date.MonthFa().ToString())
                          .Replace("D", NmeDayPersian[date.DayFa()])
                          .Replace("ddd", date.WeekDayPersian())
                          .Replace("dd", date.DayFa().ToString("D2"))
                          .Replace("d", date.DayFa().ToString())
                          .Replace("hh", date.Hour.ToString("D2"))
                          .Replace("mm", date.Minute.ToString("D2"))
                          .Replace("ss", date.Second.ToString("D2")) ;
        }
    }
}
