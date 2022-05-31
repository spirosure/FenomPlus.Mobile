using System;
using FenomPlus.Views;
using Xamarin.Forms;

namespace FenomPlus.ViewModels
{
    public class HumanControlPreparingViewModel : BaseViewModel
    {
        public HumanControlPreparingViewModel()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnAppearing()
        {
            base.OnAppearing();
            TestTime = 10;
            TestSeconds = TestTime * (1000 / App.ReadBreathData);
            Stop = false;
            Device.StartTimer(TimeSpan.FromMilliseconds(App.ReadBreathData), () =>
            {
                TestSeconds--;
                if ((TestSeconds <= 0) && (Stop == false))
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(HumanControlPerformingView)}"), false);
                    });
                }

                return (TestSeconds > 0) && (Stop == false);
            });
        }

        override public void OnDisappearing()
        {
            base.OnDisappearing();
            Stop = true;
        }


        private int _TestTime;
        public int TestTime
        {
            get => _TestTime;
            set
            {
                _TestTime = value;
                OnPropertyChanged("TestTime");
            }
        }

        private bool Stop;
        private int TestSeconds;
    }
}
