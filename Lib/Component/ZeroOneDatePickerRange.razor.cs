using Blazor_PersianDatePickerZO.Hellper;
using Microsoft.AspNetCore.Components;

namespace Blazor_PersianDatePickerZO.Component
{
    partial class ZeroOneDatePickerRange : BaseDatePickerRangeZO
    {
        [Parameter]
        public bool PupupDatePickerZO { get; set; }

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
            SelectDateFirst = DateTime.Now.AddDays(-1);
            SelectDateLast = DateTime.Now;
            Change();
        }
        void GetWeekRange()
        {
            SelectDateFirst = DateTime.Now.AddDays(-7);
            SelectDateLast = DateTime.Now;
            Change();
        }
        void GetMonthRange()
        {
            SelectDateFirst = DateTime.Now.AddMonths(-1);
            SelectDateLast = DateTime.Now;
            Change();
        }
        void GetYearRange()
        {
            SelectDateFirst = DateTime.Now.AddYears(-1);
            SelectDateLast = DateTime.Now;
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
