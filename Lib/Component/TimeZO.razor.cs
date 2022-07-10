using Blazor_PersianDatePickerZO.Hellper;


namespace Blazor_PersianDatePickerZO.Component
{
    partial class TimeZO: BaseDatePickerZO
    {

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
                SelectDate = SelectDate.Date.Add(tim);

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
                SelectDate = SelectDate.Date.Add(tim);
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
                SelectDate = SelectDate.Date.Add(tim);
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
    }
}
