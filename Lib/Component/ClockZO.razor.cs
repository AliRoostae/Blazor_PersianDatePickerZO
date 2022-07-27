using Blazor_PersianDatePickerZO.Hellper;
using Microsoft.AspNetCore.Components;

namespace Blazor_PersianDatePickerZO.Component
{
    partial class ClockZO
    {

        [Parameter]
        public virtual TimeSpan SelectTime { get; set; } = DateTime.Now.TimeOfDay;
        [Parameter]
        public virtual bool NoChangeClock { get; set; }

        [Parameter]
        public virtual EventCallback<TimeSpan> SelectTimeChanged { get; set; }

        [Parameter]
        public ThemeDatePickerZO ThemePickerZO { get; set; } = ThemeDatePickerZO.lightgreen;

        double _dgH => SelectTime.TotalHours * 30 + 90;
        double _dgM => SelectTime.Minutes * 6 + 90;
        double _dgS => SelectTime.Seconds * 6 + 90;

        string _amPm => SelectTime.Hours >= 12 ? "ب.ظ 🌓" : "ق.ظ 🌘";
        void CheangAmPm()
        {
            
                SelectTime = new TimeSpan(SelectTime.Hours >= 12? SelectTime.Hours-12: SelectTime.Hours+12, SelectTime.Minutes, SelectTime.Seconds);
            SelectTimeChanged.InvokeAsync(SelectTime);
            _defultSelected = ClockHand.NoSelect;
        }
        ClockHand _defultSelected = ClockHand.NoSelect;

        string _classEditTime => _defultSelected == ClockHand.NoSelect ? string.Empty : "triangle";
        void SetDef(ClockHand argo)
        {
            if (NoChangeClock) return;
            _defultSelected = argo;

        }


        void SetTimeByClockHand(int i)
        {
            if (NoChangeClock) return;
            switch (_defultSelected)
            {
                case ClockHand.Hourse:
                    SelectTime = new TimeSpan((int)(i / 5), SelectTime.Minutes, SelectTime.Seconds);
                    break;
                case ClockHand.Minute:
                    SelectTime = new TimeSpan(SelectTime.Hours, i, SelectTime.Seconds);
                    break;
                case ClockHand.Second:
                    SelectTime = new TimeSpan(SelectTime.Hours, SelectTime.Minutes, i);
                    break;
            }
            SelectTimeChanged.InvokeAsync(SelectTime);
            _defultSelected = ClockHand.NoSelect;
        }

        enum ClockHand
        {
            Hourse,
            Minute,
            Second,
            NoSelect
        }

    }
}
