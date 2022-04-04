using System;
using FenomPlus.Helpers;
using FenomPlus.Models;
using FenomPlus.SDK.Core.Models.Characteristic;
using FenomPlus.Views;
using Xamarin.Forms;

namespace FenomPlus.ViewModels
{
    public class BreathManeuverFeedbackViewModel : BaseViewModel
    {
        public BreathManeuverFeedbackViewModel()
        {
        }

        private bool Stop;

        /// <summary>
        /// 
        /// </summary>
        public string TestType
        {
            get { return (App.TestType == TestTypeEnum.Standard) ? "Standard Test" : "Short Test"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int TestTime
        {
            get { return (App.TestType == TestTypeEnum.Standard) ? 10 : 6; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnAppearing()
        {
            Stop = false;
            TestSeconds = TestTime * (1000 / App.ReadBreathData);
            GuageData = 0;
            GuageSeconds = TestTime * (1000 / App.ReadBreathData);
            GuageStatus = "Exhale Harder";

            // TODO: start mesurement to ble
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (App.BleDevice != null)
                {
                    _ = await App.BleDevice.StartMesurementFeature(
                        (App.TestType == TestTypeEnum.Standard) ?
                        BreathTestEnum.Start10Second :
                        BreathTestEnum.Start6Second);
                    var breathManeuvera = App.BleDevice.ReadBreathManeuverFeature();
                }
            });   

            // start timer
            Device.StartTimer(TimeSpan.FromMilliseconds(App.ReadBreathData), () =>
            {
                TestSeconds--;
                if ((TestSeconds <= 0) && (Stop == false))
                {
                        // TODO: read value from ble ppb?
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            if (App.BleDevice != null)
                            {
                                App.TestResult = App.BleDevice.ReadMesurementFeature().Result;

                                // TODO: send stop to ble here
                                _ = App.BleDevice?.StopMesurementFeature();
                            }
                            // stop exhale here
                            await Shell.Current.GoToAsync(nameof(StopExhalingView));
                        });
                }

                Device.BeginInvokeOnMainThread(async () => {
                    // TODO: read from ble charestic
                    if ((Stop == false) && (App.BleDevice != null) && (App.BleDevice.Connected))
                    {
                        var breathManeuver = await App.BleDevice.ReadBreathManeuverFeature();
                        if (breathManeuver != null)
                        {
                            App.TestResult = breathManeuver.NOScore;
                            GuageData = (float)(((float)breathManeuver.BreathFlow) / 10);

                            if (GuageData < 2.8f)
                            {
                                GuageStatus = "Exhale Harder";
                            }
                            else if (GuageData > 3.2f)
                            {
                                GuageStatus = "Exhale Softer";
                            }
                            else
                            {
                                GuageStatus = "Good Job!";
                            }
                        }
                    }
                });
                // return contiune of below the time
                GuageSeconds = TestSeconds / (1000 / App.ReadBreathData);
                return (TestSeconds > 0) && (Stop == false);
            });
        }

        public void OnDisappearing()
        {
            Stop = true;
            PlaySounds.StopAll();
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

        private int TestSeconds;

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
                PlaySounds.PlaySound(GuageData);
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
