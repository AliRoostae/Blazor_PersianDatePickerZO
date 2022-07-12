using Blazor_PersianDatePickerZO.Hellper;
using System.Globalization;

namespace Blazor_PersianDatePickerZO.Component
{
    partial class YearZO: BaseDatePickerZO
    {

        int _startLoop()
        {
            var temp = YearSelect - 1;
            return CalculateYear(temp);

        }
        int YearSelect
        {
            get => SelectDate.YearFa();
            set => Selected(value);
        }



        void NextElement()
        {
            
            ++YearSelect;
            Selected(YearSelect);
        }

        void PrevElement()
        {
           
            --YearSelect;
            Selected(YearSelect);

        }



        void Selected(int argo)
        {
            if (!IsActiveYear(argo)) return;
            argo = CalculateYear(argo);

            var tempselect = DatePickerZeroOneHellper.Persian.ToDateTime(argo, SelectDate.MonthFa(), 1, 0, 0, 0, 1, PersianCalendar.PersianEra);
            var day = SelectDate.DayFa() > tempselect.DaysInMonth() ? tempselect.DaysInMonth() : SelectDate.DayFa();
            SelectDate = DatePickerZeroOneHellper.Persian.ToDateTime(argo, SelectDate.MonthFa(), day, SelectDate.Hour, SelectDate.Minute, SelectDate.Second, 0, PersianCalendar.PersianEra);
            SelectDateChanged.InvokeAsync(SelectDate);
        }

        protected int CalculateYear(int argo)
        {
            if (argo < _minYearFa) return _maxYearFa;
            if (argo > _maxYearFa) return _minYearFa;
            return argo;
        }

       
        protected bool IsActiveYear(int year)
        {
            return year >= MinDate.YearFa() && year <= MaxDate.YearFa();
        }
    }
}
