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
            TestSeconds = TestTime * (1000 / Cache.ReadBreathData);
            Stop = false;

            Device.StartTimer(TimeSpan.FromMilliseconds(Cache.ReadBreathData), () =>
            {
                TestSeconds--;
                TestTime = TestSeconds / (1000 / Cache.ReadBreathData);
                if ((TestSeconds <= 0) && (Stop == false))
                {
                    BleHub.StopTest();

                    QualityControlDataModel model = new QualityControlDataModel()
                    {
                        DateTaken = DateTime.Now,
                        User = Services.Cache.QCUsername,
                        TestResult = Cache._BreathManeuver.NOScore,
                        SerialNumber = this.DeviceSerialNumber,
                        QCStatus = "",
                        QCExpiration = "",
                    };

                    // depending on result
                    if ((Cache._BreathManeuver.NOScore >= BreathGuage.LowGreen) && (Cache._BreathManeuver.NOScore <= BreathGuage.HighGreen))
                    {
                        model.QCStatus = "Qualified";
                        QCRepo.Insert(model);
                        // log passed here
                        Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(HumanControlPassedView)}"), false);
                    }
                    else
                    {
                        model.QCStatus = "Disqualified";
                        QCRepo.Insert(model);
                        // log failed here
                        Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(HumanControlDisqualifiedView)}"), false);
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
