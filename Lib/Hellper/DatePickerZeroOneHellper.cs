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


    }
}
