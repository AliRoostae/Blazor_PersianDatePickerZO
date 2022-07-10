using Blazor_PersianDatePickerZO.Hellper;
using System.Globalization;

namespace Blazor_PersianDatePickerZO.Component
{
    public partial class DayZO: BaseDatePickerZO
    {

        int _usInmont = 0;
        int _contDayMont => SelectDate.DaysInMonth();
        int _contDayMontlast => SelectDate.DaysInMonth();
        int _strartDayWeek => SelectDate.OneDayMonthDayWeek();
        int _daySelect => SelectDate.DayFa();

        void Selected(int day)
        {
            SelectDate = DatePickerZeroOneHellper.Persian.ToDateTime(SelectDate.YearFa(), SelectDate.MonthFa(), day, SelectDate.Hour, SelectDate.Minute, SelectDate.Second, 0, PersianCalendar.PersianEra);

            SelectDateChanged.InvokeAsync(SelectDate);


        }
    }
}
