using System;
using FenomPlus.Models;
using FenomPlus.Views;
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
        public void OnAppearing()
        {
            Stop = false;
            Seconds = 25;
            Device.StartTimer(TimeSpan.FromSeconds(1), TimerCallback);
        }

        /// <summary>
        /// 
        /// </summary>
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
                    await Shell.Current.GoToAsync(nameof(TestResultsView));
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

        public string TestType
        {
            get { return (App.TestType == TestTypeEnum.Standard) ? "Standard Test Result" : "Short Test Result"; }
        }
    }
}

