using Microsoft.AspNetCore.Components;

namespace Blazor_PersianDatePickerZO.Hellper
{
    public abstract class BaseDatePickerZO : ComponentBase
    {


        [Parameter]
        public DateTime SelectDate
        {
            get => _selectDate; set
            {

                if (value < MinDate) value = MaxDate;
                if (value > MaxDate) value = MinDate;
                _selectDate = value;

            }
        }
        [Parameter]
        public EventCallback<DateTime> SelectDateChanged { get; set; }

        DateTime _minFa;
        [Parameter]
        public DateTime MinDate
        {
            get => _minFa < _minFaFix || _minFa > _maxFaFix ? _minFaFix : _minFa;
            set
            {

                if (value < _minFaFix) value = _minFaFix;
                if (value > _maxFaFix) value = _maxFaFix;
                _minFa = value;
            }
        }
        [Parameter]
        public EventCallback<DateTime> MinDateChanged { get; set; }


        DateTime _maxFa;
        [Parameter]
        public DateTime MaxDate
        {
            get => _maxFa < _minFaFix || _maxFa > _maxFaFix ? _maxFaFix : _maxFa;
            set
            {

                if (value < _minFaFix) value = _minFaFix;
                if (value > _maxFaFix) value = _maxFaFix;
                _maxFa = value;
            }
        }
        [Parameter]
        public EventCallback<DateTime> MaxDateChanged { get; set; }




        protected DateTime _maxFaFix => DatePickerZeroOneHellper.Persian.MaxSupportedDateTime;
        protected DateTime _minFaFix => DatePickerZeroOneHellper.Persian.MinSupportedDateTime;

        protected int _minYearFa => MinDate.YearFa();
        protected int _maxYearFa => MaxDate.YearFa();

        DateTime _selectDate = DateTime.Now;
        protected int CalculateYear(int argo)
        {
            if (argo < _minYearFa) return _maxYearFa;
            if (argo > _maxYearFa) return _minYearFa;
            return argo;
        }

    }
}
