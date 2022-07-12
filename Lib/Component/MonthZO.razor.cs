﻿using Blazor_PersianDatePickerZO.Hellper;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Blazor_PersianDatePickerZO.Component
{
    partial class MonthZO: BaseDatePickerZO
    {
        string[] _monthFa => new[] { "", "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذز", "دی", "بهمن", "اسفند" };

        int _colectForMontStart => MonthSelect <= 1 ? 1 : MonthSelect > 10 ? 10 : MonthSelect - 1;

        int MonthSelect
        {
            get => SelectDate.MonthFa();


            set
            {
                if (!IsActiveMonth(value)) return;
                Selected(value);


            }
        }


        void NextElement()
        {
            ++MonthSelect;
            Selected(MonthSelect);
        }

        void PrevElement()
        {
            --MonthSelect;
            Selected(MonthSelect);
        }

        void Selected(int argo)
        {

            var tempselect = DatePickerZeroOneHellper.Persian.ToDateTime(SelectDate.YearFa(), argo, 1, 0, 0, 0, 1, PersianCalendar.PersianEra);
            var day = SelectDate.DayFa() > tempselect.DaysInMonth() ? tempselect.DaysInMonth() : SelectDate.DayFa();
            SelectDate = DatePickerZeroOneHellper.Persian.ToDateTime(SelectDate.YearFa(), argo, day, SelectDate.Hour, SelectDate.Minute, SelectDate.Second, 0, PersianCalendar.PersianEra);

            SelectDateChanged.InvokeAsync(SelectDate);
        }

      
        protected bool IsActiveMonth(int month)
        {

            int.TryParse($"{SelectDate.YearFa():D2}{month:D2}", out var selectMonth);
            int.TryParse($"{MinDate.YearFa():D2}{MinDate.MonthFa():D2}", out var min);
            int.TryParse($"{MaxDate.YearFa():D2}{MaxDate.MonthFa():D2}", out var max);
            return selectMonth >= min && selectMonth <= max ;
        }

    }
}
