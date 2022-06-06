using System;
using FenomPlus.Controls;
using FenomPlus.Models;
using FenomPlus.Views;
using Xamarin.Forms;

namespace FenomPlus.ViewModels
{
    public class HumanControlPerformingViewModel : BaseViewModel
    {
        public HumanControlPerformingViewModel()
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
                TestTime = TestSeconds / (1000 / App.ReadBreathData);
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

                        QualityControlDataModel model = new QualityControlDataModel()
                        {
                            DateTaken = DateTime.Now,
                            User = Services.Cache.QCUsername,
                            TestResult = App.TestResult,
                            SerialNumber = this.DeviceSerialNumber,
                            QCStatus = "",
                            QCExpiration = "",
                        };
                        // depending on result
                        if ((App.TestResult >= BreathGuage.LowGreen) && (App.TestResult <= BreathGuage.HighGreen))
                        {
                            model.QCStatus = "Qualified";
                            QCRepo.Insert(model);
                            // log passed here
                            await Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(HumanControlPassedView)}"), false);
                        }
                        else
                        {
                            model.QCStatus = "Disqualified";
                            QCRepo.Insert(model);
                            // log failed here
                            await Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(HumanControlDisqualifiedView)}"), false);
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
