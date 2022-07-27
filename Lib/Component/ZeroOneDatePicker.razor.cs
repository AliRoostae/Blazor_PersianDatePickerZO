using Blazor_PersianDatePickerZO.Hellper;
using Microsoft.AspNetCore.Components;

namespace Blazor_PersianDatePickerZO.Component
{
    partial class ZeroOneDatePicker : BaseDatePickerZO
    {


        
        [Parameter]
        public bool PupupDatePickerZO { get; set; }

        [Parameter]
        public EventCallback<string> DateFa { get; set; }

        // yyyy/MM/dd hh:mm:ss 1359/04/09 21:00:00
        // yy/MM/dd hh:mm:ss   59/09/04 21:00:00
        // yyyy/M/d hh:mm:ss 1359/4/9 21:00:00
        // MMM تیر
        //ddd یک شنبه
        //D  نهم

        [Parameter]
        public string Format { get; set; } = "yyyy/MM/dd hh:mm:ss";

        string _dateFa => SelectDate.FormatDate(Format);
        DateTime _olddate;
        bool _show;
        void ShowPicker()
        {
            _show = !_show;
            SelectDate = _olddate;
            Change();
        }

        void ColsePopup()
        {
            _show = false;
             _olddate= SelectDate;
            Change();
        }
        void Change()
        {

            SelectDateChanged.InvokeAsync(SelectDate);
            DateFa.InvokeAsync(_dateFa);

      
        }
        void GetToday()
        {
            SelectDate = DateTime.Now;
           
            ColsePopup();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {

                Change();
                _olddate = SelectDate;
            }
        }

    }
}
