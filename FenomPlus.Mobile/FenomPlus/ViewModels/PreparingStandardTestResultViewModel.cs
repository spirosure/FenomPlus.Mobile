using System;
using FenomPlus.Models;
using FenomPlus.SDK.Core.Models.Characteristic;
using Xamarin.Forms;

namespace FenomPlus.ViewModels
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
        override public void OnAppearing()
        {
            base.OnAppearing();
            if (App.TestType == TestTypeEnum.Standard)
            {
                TestType = "Standard Test Result";
            }
            else
            {
                TestType = "Short Test Result";
            }


            Stop = false;
            Seconds = 28;
            Device.StartTimer(TimeSpan.FromSeconds(1), TimerCallback);
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnDisappearing()
        {
            base.OnDisappearing();
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
                    if (App.BleDevice != null)
                    {
                        BreathManeuver breathManeuver = await App.BleDevice.ReadBreathManeuverFeature();
                        if (breathManeuver != null)
                        {
                            App.TestResult = breathManeuver.NOScore;
                            Services.Database.BreathManeuverRepo.Insert(breathManeuver);
                        }
                    }
                    await Shell.Current.GoToAsync(new ShellNavigationState($"///TestResultsView"), false);
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

        private string _TestType;
        public string TestType
        {
            get => _TestType;
            set
            {
                _TestType = value;
                OnPropertyChanged("TestType");
            }
        }

    }
}

