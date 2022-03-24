using System;
using FenomPlus.Sandbox.Helpers;
using FenomPlus.Sandbox.Views;
using FenomPlus.SDK.Core.Models.Characteristic;
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
            TestSeconds = 10 * (1000 / App.ReadBreathData);
            GuageData = 0;
            GuageSeconds = 10 * (1000 / App.ReadBreathData);
            GuageStatus = "Exhale Harder";

            // TODO: start mesurement to ble
            //Device.BeginInvokeOnMainThread(async () => {
            _ = App.BleDevice.StartMesurementFeature(BreathTestEnum.Start10Second);
                // var breathManeuvera = App.BleDevice.ReadBreathManeuverFeature();
            //});   

            // start timer
            Device.StartTimer(TimeSpan.FromMilliseconds(App.ReadBreathData), () =>
            {
                TestSeconds--;
                if (TestSeconds <= 0)
                {
                    // ok time to goto next page here
                    if (!Stop)
                    {
                        // TODO: read value from ble ppb?
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            //App.TestResult = App.BleDevice.ReadMesurementFeature().Result;

                            // TODO: send stop to ble here
                            _ = App.BleDevice.StopMesurementFeature();

                            // stop exhale here
                            await Shell.Current.GoToAsync(nameof(StopExhalingPage));
                        });

                    }
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
