using System;
using FenomPlus.Views;
using Xamarin.Forms;

namespace FenomPlus.ViewModels
{
    public class NegativeControlPerformViewModel : BaseViewModel
    {
        public NegativeControlPerformViewModel()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnAppearing()
        {
            base.OnAppearing();
            TestTime = 10;
            TestSeconds = TestTime * (1000 / Cache.ReadBreathData);
            Stop = false;

            Device.StartTimer(TimeSpan.FromMilliseconds(Cache.ReadBreathData), () =>
            {
                TestSeconds--;
                TestTime = TestSeconds / (1000 / Cache.ReadBreathData);
                if ((TestSeconds <= 0) && (Stop == false))
                {
                    BleHub.StopTest();
                    if (Cache._BreathManeuver.NOScore <= 0)
                    {
                        Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(NegativeControlPassView)}"), false);
                    }
                    else
                    {
                        Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(NegativeControlFailView)}"), false);
                    }
                }

                return (TestSeconds > 0) && (Stop == false);
            });
        }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        override public void NewGlobalData()
        {
            base.NewGlobalData();
        }
    }
}
