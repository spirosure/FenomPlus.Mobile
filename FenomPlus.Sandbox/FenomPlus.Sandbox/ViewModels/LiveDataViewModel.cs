using System;
using FenomPlus.Sandbox.Views;
using FenomPlus.SDK.Core.Models.Characteristic;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.ViewModels
{
    public class LiveDataViewModel : BaseViewModel
    {
        public LiveDataViewModel()
        {
        }

        private bool Stop;

        /// <summary>
        /// 
        /// </summary>
        public void OnAppearing()
        {
            Stop = false;
            Temperature = "0";
            Pressure = "0";
            NOScore = 0;
            GuageData = 0;
            GuageSeconds = 10 * 4;
            GuageStatus = "Exhale Harder";

            // TODO: start mesurement to ble
            //Device.BeginInvokeOnMainThread(async () => {
            _ = App.BleDevice.StartMesurementFeature(BreathTestEnum.Start10Second);

            // start timer
            Device.StartTimer(TimeSpan.FromMilliseconds(250), () =>
            {
                Device.BeginInvokeOnMainThread(async () => {
                    if((Stop==false) && (App.BleDevice != null) && (App.BleDevice.Connected)) { 
                        var breathManeuver = await App.BleDevice.ReadBreathManeuverFeature();
                        if (breathManeuver != null)
                        {
                            Temperature = breathManeuver.Temperature.ToString();
                            Pressure = (breathManeuver.Pressure*10).ToString();
                            NOScore = breathManeuver.NOScore;
                            GuageData = (float)(((float)breathManeuver.BreathFlow) / 10);
                        }
                    }
                });
                return (Stop==false);
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

        private string temperature;
        public string Temperature
        {
            get => "Temperature: " + temperature;
            set
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        private string pressure;
        public string Pressure
        {
            get => "Pressure: " + pressure;
            set
            {
                pressure = value;
                OnPropertyChanged("Pressure");
            }
        }

        private float nOScore;
        public float NOScore
        {
            get => nOScore;
            set
            {
                nOScore = value;
                OnPropertyChanged("NOScore");
            }
        }
        
            
            
    }
}
