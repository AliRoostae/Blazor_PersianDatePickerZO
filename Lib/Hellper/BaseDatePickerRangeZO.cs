using Microsoft.AspNetCore.Components;

namespace Blazor_PersianDatePickerZO.Hellper
{
    public abstract class BaseDatePickerRangeZO : BaseDatePickerZO
    {
        private new DateTime SelectDate { get; set; }
        private new EventCallback<DateTime> SelectDateChanged { get; set; }
        private new DateTime MinDate { get; set; } = DatePickerZeroOneHellper.Persian.MinSupportedDateTime;
        private new DateTime MaxDate { get; set; } = DatePickerZeroOneHellper.Persian.MaxSupportedDateTime;

        DateTime _selectDateFirst = DateTime.Now.AddDays(-1);
        [Parameter]
        public DateTime SelectDateFirst
        {
            get => _selectDateFirst;
            set
            {
                if (value < MinDate) value = MinDate;
                if (value > MaxDate) value = MaxDate.AddMinutes(-1);
                _selectDateFirst = value;
            }
        }

        [Parameter]
        public virtual EventCallback<DateTime> SelectDateFirstChanged { get; set; }

        DateTime _selectDateLast = DateTime.Now.AddDays(1);
        [Parameter]
        public DateTime SelectDateLast
        {
            get => _selectDateLast;
            set
            {
                if (value < MinDate) value = MinDate.AddMinutes(1);
                if (value > MaxDate) value = MaxDate;
                _selectDateLast = value;
            }
        }

        [Parameter]
        public virtual EventCallback<DateTime> SelectDateLastChanged { get; set; }



       


        // yyyy/MM/dd hh:mm:ss 1359/04/09 21:00:00
        // yy/MM/dd hh:mm:ss   59/09/04 21:00:00
        // yyyy/M/d hh:mm:ss 1359/4/9 21:00:00
        // MMM تیر
        //ddd یک شنبه
        //D  نهم

        [Parameter]
        public string Format { get; set; } = "yyyy/MM/dd hh:mm";

        protected string _dateFa => $"{SelectDateFirst.FormatDate(Format)} ~ {SelectDateLast.FormatDate(Format)}";
        protected string _dateFaFirst => SelectDateFirst.FormatDate(Format);
        protected string _dateFaLast => SelectDateLast.FormatDate(Format);





    }
}
