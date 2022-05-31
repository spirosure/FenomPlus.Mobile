using System;
using FenomPlus.Sandbox.Views;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.ViewModels
{
    public class PreparingStandardTestResultViewModel : BaseViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public PreparingStandardTestResultViewModel()
        {
            
        }

        private bool Stop;

        /// <summary>
        /// 
        /// </summary>
        public void OnAppearing()
        {
            Stop = false;
            Seconds = 28;
            Device.StartTimer(TimeSpan.FromSeconds(1), TimerCallback);
        }

        public void OnDisappearing()
        {
            Stop = true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool TimerCallback()
        {
            Seconds--;
            if (Seconds <= 0)
            {
                // ok time to goto next page here
                Device.BeginInvokeOnMainThread(async () =>
                {
                    // read value again 
                    var breathManeuver = await App.BleDevice.ReadBreathManeuverFeature();
                    if (breathManeuver != null)
                    {
                        App.TestResult = breathManeuver.NOScore;
                    }

                    if (Stop == false)
                    {
                        await Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(StandardTestResultPage)}"), false);
                    }
                });
            }
            return Seconds > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        private int seconds;
        public int Seconds
        {
            get => seconds;
            set
            {
                seconds = value;
                OnPropertyChanged("Seconds");
            }
        }
    }
}

