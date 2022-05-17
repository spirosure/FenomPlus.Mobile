        using System;
using FenomPlus.Sandbox.Views;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.ViewModels
{
    public class StopExhalingViewModel : BaseViewModel
    {
        public StopExhalingViewModel()
        {
            
        }


        private bool Stop;

        public void OnAppearing()
        {
            Stop = false;
            Seconds = 2;
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
                Device.BeginInvokeOnMainThread(async () =>
                {
                    // ok time to goto next page here
                    if (Stop == false)
                    {
                        await Shell.Current.GoToAsync(new ShellNavigationState($"///PreparingStandardTestResultPage"), false);
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
