using System;
using FenomPlus.Sandbox.Views;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.ViewModels
{
    public class GaugeViewModel : BaseViewModel
    {
        public GaugeViewModel()
        {
        }

        private bool Stop;

        /// <summary>
        /// 
        /// </summary>
        public void OnAppearing()
        {
            Stop = false;
            GuageSeconds = 10;
            GuageStatus = "Exhale Harder";
            GuageStatus = "Good Job!";
            GuageStatus = "Exhale Softer";
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                GuageSeconds--;
                if (GuageSeconds <= 0)
                {
                    // ok time to goto next page here
                    if (!Stop)
                    {
                        Device.BeginInvokeOnMainThread(() => Shell.Current.GoToAsync(nameof(StopExhalingPage)));
                    }
                }
                return GuageSeconds > 0;
            });

            GuageData = 0;
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                

                if (GuageData < 2.8f)
                {
                    GuageData += 0.1f;
                    GuageStatus = "Exhale Harder";
                }
                else if (GuageData > 3.2f)
                {
                    GuageData += 0.1f;
                    GuageStatus = "Exhale Softer";
                }
                else
                {
                    GuageData += 0.02f;
                    GuageStatus = "Good Job!";
                }

                return GuageSeconds > 0;
            });
        }

        public void OnDisappearing()
        {
            Stop = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartBleNotify()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void StopBleNotify()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private int guageSeconds;
        public int GuageSeconds
        {
            get => guageSeconds;
            set
            {
                guageSeconds = value;
                OnPropertyChanged("GuageSeconds");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private float guageData;
        public float GuageData
        {
            get => guageData;
            set
            {
                guageData = value;
                OnPropertyChanged("GuageData");
            }
        }

        private string guageStatus;
        public string GuageStatus
        {
            get => guageStatus;
            set
            {
                guageStatus = value;
                OnPropertyChanged("GuageStatus");
            }
        }
        
    }
}
