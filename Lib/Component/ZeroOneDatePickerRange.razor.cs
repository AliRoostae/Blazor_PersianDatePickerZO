using Blazor_PersianDatePickerZO.Hellper;
using Microsoft.AspNetCore.Components;

namespace Blazor_PersianDatePickerZO.Component
{
    partial class ZeroOneDatePickerRange : BaseDatePickerRangeZO
    {
        [Parameter]
        public bool PopupDatePickerZO { get; set; }

        [Parameter]
        public EventCallback<string> DateFa { get; set; }



        DateTime _olddateFirst;
        DateTime _olddateLast;
        bool _show;
        protected void ShowPicker()
        {
            _show = !_show;
            SelectDateFirst = _olddateFirst;
            SelectDateLast = _olddateLast;
            Change();
        }

        protected void ColsePopup()
        {
            _show = false;
            Change();
        }
        protected void Change()
        {

            SelectDateFirstChanged.InvokeAsync(SelectDateFirst);
            SelectDateLastChanged.InvokeAsync(SelectDateLast);
            DateFa.InvokeAsync(_dateFa);
        }


        void GetDayRange()
        {
            SelectDateFirst = SelectDateLast.AddDays(-1);
            Change();
        }
        void GetWeekRange()
        {
            SelectDateFirst = SelectDateLast.AddDays(-7);
            Change();
        }
        void GetMonthRange()
        {
            SelectDateFirst = SelectDateLast.AddMonths(-1);
            Change();
        }
        void GetYearRange()
        {
            SelectDateFirst = SelectDateLast.AddYears(-1);
            Change();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {

                Change();
                _olddateFirst = SelectDateFirst;
                _olddateLast = SelectDateLast;
            }
        }
    }
}
