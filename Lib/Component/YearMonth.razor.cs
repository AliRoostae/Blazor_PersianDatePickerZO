using Blazor_PersianDatePickerZO.Hellper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_PersianDatePickerZO.Component
{
    partial class YearMonth :  BaseDatePickerZO
    {

        bool _monthShow;
        bool _yearhShow;

        void ShowPanel(bool yearT_monthF)
        {
            if (yearT_monthF)
            {
                _monthShow = false;
                _yearhShow = true;

            }
            else
            { 
                _yearhShow = false;
                _monthShow = true;
               
            }
        }

        int _startLoop()
        {
            var temp = YearSelect - 6;
            return CalculateYear(temp);

        }
        int YearSelect
        {
            get => SelectDate.YearFa();
            set => SelectedYear(value);
        }



        int MonthSelect
        {
            get => SelectDate.MonthFa();


            set
            {
                if (!IsActiveMonth(value)) return;
                SelectedMonth(value);


            }
        }


      

        void SelectedMonth(int argo)
        {
          
            var tempselect = DatePickerZeroOneHellper.Persian.ToDateTime(SelectDate.YearFa(), argo, 1, 0, 0, 0, 1, PersianCalendar.PersianEra);
            var day = SelectDate.DayFa() > tempselect.DaysInMonth() ? tempselect.DaysInMonth() : SelectDate.DayFa();
            SelectDate = DatePickerZeroOneHellper.Persian.ToDateTime(SelectDate.YearFa(), argo, day, SelectDate.Hour, SelectDate.Minute, SelectDate.Second, 0, PersianCalendar.PersianEra);

            SelectDateChanged.InvokeAsync(SelectDate);
            _monthShow = _yearhShow = false;

        }


        protected bool IsActiveMonth(int month)
        {
            if (month < 1 || month > 12) return false;
            int.TryParse($"{SelectDate.YearFa():D2}{month:D2}", out var selectMonth);
            int.TryParse($"{MinDate.YearFa():D2}{MinDate.MonthFa():D2}", out var min);
            int.TryParse($"{MaxDate.YearFa():D2}{MaxDate.MonthFa():D2}", out var max);
            return selectMonth >= min && selectMonth <= max;
        }



        void NextElementYear()
        {

            ++YearSelect;
            SelectedYear(YearSelect);
        }

        void PrevElementYear()
        {

            --YearSelect;
            SelectedYear(YearSelect);

        }

        void SelectedYearMouse(int argo)
        {
            SelectedYear(argo);
            _monthShow = _yearhShow = false;
        }

        void SelectedYear(int argo)
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
            if (argo < _minYearFa) return _minYearFa;
            if (argo > _maxYearFa) return _maxYearFa;
            return argo;
        }


        protected bool IsActiveYear(int year)
        {
            return year >= MinDate.YearFa() && year <= MaxDate.YearFa();
        }

    }
}
