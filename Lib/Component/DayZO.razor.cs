using Blazor_PersianDatePickerZO.Hellper;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Blazor_PersianDatePickerZO.Component
{
    public partial class DayZO : BaseDatePickerZO
    {
        [Parameter]
        public  EventCallback Close { get; set; }
        int _usInmont = 0;
        int _contDayMont => SelectDate.DaysInMonth();
        int _contDayMontlast => SelectDate.DaysInMonth();
        int _strartDayWeek => SelectDate.OneDayMonthDayWeek();
        int _daySelect => SelectDate.DayFa();

        void Selected(int day)
        {
            if (!IsActiveDay(day)) return;
            SelectDate = DatePickerZeroOneHellper.Persian.ToDateTime(SelectDate.YearFa(), SelectDate.MonthFa(), day, SelectDate.Hour, SelectDate.Minute, SelectDate.Second, 0, PersianCalendar.PersianEra);

            SelectDateChanged.InvokeAsync(SelectDate);
            Close.InvokeAsync();

        }

        protected int CalculateYear(int argo)
        {
            if (argo < _minYearFa) return _maxYearFa;
            if (argo > _maxYearFa) return _minYearFa;
            return argo;
        }

        bool IsActiveDay(int day)
        {
            var temp = DatePickerZeroOneHellper.Persian.ToDateTime(SelectDate.YearFa(), SelectDate.MonthFa(), day, SelectDate.Hour, SelectDate.Minute, SelectDate.Second, 0, PersianCalendar.PersianEra);
            return temp > MinDate && temp < MaxDate;
        }

    }
}
