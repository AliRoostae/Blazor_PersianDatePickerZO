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
            argo = CalculateYear(argo);

            var tempselect = DatePickerZeroOneHellper.Persian.ToDateTime(argo, SelectDate.MonthFa(), 1, 0, 0, 0, 1, PersianCalendar.PersianEra);
            var day = SelectDate.DayFa() > tempselect.DaysInMonth() ? tempselect.DaysInMonth() : SelectDate.DayFa();
            SelectDate = DatePickerZeroOneHellper.Persian.ToDateTime(argo, SelectDate.MonthFa(), day, SelectDate.Hour, SelectDate.Minute, SelectDate.Second, 0, PersianCalendar.PersianEra);
            SelectDateChanged.InvokeAsync(SelectDate);
        }
    }
}
