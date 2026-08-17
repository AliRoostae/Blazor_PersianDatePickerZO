using Blazor_PersianDatePickerZO.Helper;
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
       
         int _lastYearFa;
         int _lastMonthFa;
         int _lastDayFa;
         ThemeDatePickerZO _lastTheme;

        // قدم ۴: خود متد override
        protected override bool ShouldRender()
        {
            // مقادیر فعلی رو می‌گیریم
            var yearFa = SelectDate.YearFa();
            var monthFa = SelectDate.MonthFa();
            var dayFa = SelectDate.DayFa();

            // مقایسه با مقدار قبلی
            bool changed = yearFa != _lastYearFa
                        || monthFa != _lastMonthFa
                        || dayFa != _lastDayFa
                        || ThemePickerZO != _lastTheme;

     
            _lastYearFa = yearFa;
            _lastMonthFa = monthFa;
            _lastDayFa = dayFa;
            _lastTheme = ThemePickerZO;

            return changed;
        }


        void Selected(int day)
        {
            if (!IsActiveDay(day)) return;
            SelectDate = DatePickerZeroOneHellper.Persian.ToDateTime(SelectDate.YearFa(), SelectDate.MonthFa(), day, Hour, Minute,Second, 0, PersianCalendar.PersianEra);

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
            var temp = DatePickerZeroOneHellper.Persian.ToDateTime(SelectDate.YearFa(), SelectDate.MonthFa(), day, Hour, Minute, Second, 0, PersianCalendar.PersianEra);
            return temp > MinDate && temp < MaxDate;
        }

    }
}
