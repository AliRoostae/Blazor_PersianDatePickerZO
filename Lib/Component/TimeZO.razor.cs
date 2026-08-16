using Blazor_PersianDatePickerZO.Helper;


namespace Blazor_PersianDatePickerZO.Component
{
    partial class TimeZO : BaseDatePickerZO
    {


        private int _lastHour;
        private int _lastMinute;
        private int _lastSecond;
        private ThemeDatePickerZO _lastTheme;
        private bool _lastSingelUs;

        protected override bool ShouldRender()
        {
            bool changed = SelectDate.Hour != _lastHour
                        || SelectDate.Minute != _lastMinute
                        || SelectDate.Second != _lastSecond
                        || ThemePickerZO != _lastTheme
                        || SingelUs != _lastSingelUs;

            _lastHour = SelectDate.Hour;
            _lastMinute = SelectDate.Minute;
            _lastSecond = SelectDate.Second;
            _lastTheme = ThemePickerZO;
            _lastSingelUs = SingelUs;

            return changed;
        }
        int Hours
        {
            get => SelectDate.Hour;
            set
            {
                if (value > 23)
                {
                    SelectDate = SelectDate.AddDays(1);
                    value = 0;
                }
                if (value < 0)
                {
                    SelectDate = SelectDate.AddDays(-1);
                    value = 23;
                }
                var tim = new TimeSpan(value, Minutes, Seconds);
                var temp = SelectDate.Date.Add(tim);
                if (!IsActiveForTime(temp)) return;
                SelectDate = temp;

            }
        }
        int Minutes
        {
            get => SelectDate.Minute;
            set
            {
                if (value > 59)
                {
                    ++Hours;
                    value = 0;
                }
                if (value < 0)
                {
                    --Hours;
                    value = 59;
                }
                var tim = new TimeSpan(Hours, value, Seconds);
                var temp = SelectDate.Date.Add(tim);
                if (!IsActiveForTime(temp)) return;
                SelectDate = temp;

            }
        }
        int Seconds
        {
            get => SelectDate.Second;
            set
            {
                if (value > 59)
                {
                    ++Minutes;
                    value = 0;
                }
                if (value < 0)
                {
                    --Minutes;
                    value = 59;
                }
                var tim = new TimeSpan(Hours, Minutes, value);
                var temp = SelectDate.Date.Add(tim);
                if (!IsActiveForTime(temp)) return;
                SelectDate = temp;
            }
        }


        void NextElement(TimeSelect type)
        {
            switch (type)
            {
                case TimeSelect.Hours:
                    ++Hours;
                    break;
                case TimeSelect.Minutes:
                    ++Minutes;
                    break;
                case TimeSelect.Seconds:
                    ++Seconds;
                    break;
            }

            SelectDateChanged.InvokeAsync(SelectDate);
        }
        void PrevElement(TimeSelect type)
        {
            switch (type)
            {
                case TimeSelect.Hours:
                    --Hours;
                    break;
                case TimeSelect.Minutes:
                    --Minutes;
                    break;
                case TimeSelect.Seconds:
                    --Seconds;
                    break;
            }

            SelectDateChanged.InvokeAsync(SelectDate);
        }

        protected bool IsActiveForTime(DateTime date)
        {
            return date > MinDate && date < MaxDate;
        }
    }
}
