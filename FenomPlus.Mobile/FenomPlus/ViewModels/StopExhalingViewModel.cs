﻿using System;
using FenomPlus.Views;
using Xamarin.Forms;

namespace FenomPlus.ViewModels
{
    public class StopExhalingViewModel : BaseViewModel
    {
        public StopExhalingViewModel()
        {

        }

        private bool Stop;

        /// <summary>
        /// 
        /// </summary>
        override public void OnAppearing()
        {
            base.OnAppearing();
            Stop = false;
            Seconds = Config.StopExhalingReadyWait;
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
            if (Stop == true) seconds = 0;
            if ((Seconds <= 0) && (Stop == false))
            {
                Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(PreparingStandardTestResultView)}"), false);
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

        /// <summary>
        /// 
        /// </summary>
        override public void NewGlobalData()
        {
            base.NewGlobalData();
        }
    }
}
