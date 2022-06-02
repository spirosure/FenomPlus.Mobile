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
            TestSeconds = TestTime * (1000 / App.ReadBreathData);
            Stop = false;

            Device.StartTimer(TimeSpan.FromMilliseconds(App.ReadBreathData), () =>
            {
                TestSeconds--;
                if ((TestSeconds <= 0) && (Stop == false))
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        App.TestResult = 0;

                        if (App.BleDevice != null)
                        {
                            App.TestResult = App.BleDevice.ReadNOScoreFeature().Result;

                            // TODO: send stop to ble here
                            _ = App.BleDevice?.StopMesurementFeature();
                        }

                        // depending on result
                        if(App.TestResult <= 0) {
                            await Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(NegativeControlPassView)}"), false);
                        } else {
                            await Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(NegativeControlFailView)}"), false);
                        }
                    });
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
    }
}
