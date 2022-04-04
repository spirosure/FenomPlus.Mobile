using System;
using Xamarin.Forms;

namespace FenomPlus.ViewModels
{
    public class DeviceReadyViewModel : BaseViewModel
    {
        public DeviceReadyViewModel()
        {
        }

        private string message;
        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        private bool Stop;

        /// <summary>
        /// 
        /// </summary>
        override public void OnAppearing()
        {
            base.OnAppearing();
            Message = "Your Device is Connected";
            Stop = false;
            Seconds = 5;
            Device.StartTimer(TimeSpan.FromSeconds(Seconds), TimerCallback);
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
            if (Stop == false)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Shell.Current.GoToAsync(new ShellNavigationState("ChooseTestView"), false);
                });
            }
            return false;
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
