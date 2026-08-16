using Blazor_PersianDatePickerZO.Hellper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Blazor_PersianDatePickerZO.Component
{
    partial class DatePickerZO : BaseDatePickerZO, IAsyncDisposable
    {
        static int Id = 0;
        internal string _dpID { get; set; } = $"DatePickerzoID{++Id}";
       
       
        [Inject]
        private IJSRuntime JS { get; set; }
        private IJSObjectReference? _module;
        private DotNetObjectReference<DatePickerZO>? dotNetHelper;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                try
                {
                    _module = await JS.InvokeAsync<IJSObjectReference>(
                        "import", "./_content/Blazor_PersianDatePickerZO/AppDatePickerZeroOne.js");

                    dotNetHelper = DotNetObjectReference.Create(this);
                    await _module.InvokeVoidAsync("outsideClickHandler", dotNetHelper, _dpID);
                }
                catch (JSDisconnectedException) { }
                catch (JSException ex)
                {
                    Console.WriteLine($"Failed to cleanup DatePicker JS listener: {ex.Message}");
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (dotNetHelper != null)
            {
                try
                {
                    if (_module != null)
                    {
                        await _module.InvokeVoidAsync("removeOutsideClickHandler", _dpID);
                        await _module.DisposeAsync();
                    }
                }
                catch (JSDisconnectedException) { }

                dotNetHelper.Dispose();
                dotNetHelper = null;
            }
        }

        [JSInvokable]
        public void OnOutsideClick()
        {
            if(_show)
            ColsePopup();



         }


        private new bool SingelUs { get; set; }

        [Parameter]
        public bool PopupDatePickerZO { get; set; }


        

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
        bool _timeShowZO => Format.ShowTimeZoDP();
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
