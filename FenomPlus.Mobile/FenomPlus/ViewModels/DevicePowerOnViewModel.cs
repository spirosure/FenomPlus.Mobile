using System;
using System.Collections.Generic;
using FenomPlus.SDK.Core.Ble.Interface;
using FenomPlus.Views;
using Xamarin.Forms;

namespace FenomPlus.ViewModels
{
    public class DevicePowerOnViewModel : BaseViewModel
    {
        private bool Stop;

        public DevicePowerOnViewModel()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void StopScan()
        {
            Services.BleHub.StopScan();
            //Services.BleHub.Disconnect();
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartScan()
        {
            // if scanning then stop the scan
            //_ = Services.BleHub.Disconnect();
            
            //
            Seconds = 30;
            Device.StartTimer(TimeSpan.FromSeconds(1), TimerCallback);
            _ = BleHub.Scan(new TimeSpan(0, 0, 0, Seconds), async (IBleDevice bleDevice) =>
            {
                if ((bleDevice != null) && !string.IsNullOrEmpty(bleDevice.Name))
                {
                    await BleHub.StopScan();
                    var connected = await Services.BleHub.Connect(bleDevice);
                    if (connected == true)
                    {
                        Stop = true;
                        await Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(DeviceReadyView)}"), false);
                    }
                }
            }, (IEnumerable<IBleDevice> bleDevices) =>
            {

            });
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
                _ = Services.BleHub.Disconnect();
                StopScan();
                StartScan();
                return false;
            }
            return ((Seconds >= 0) && (Stop == false));
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
                //Message = string.Format("Device is Ready in {0} Seconds", seconds);
                Message = string.Format("Scanning for Device {0} Seconds", seconds);
                OnPropertyChanged("Seconds");
            }
        }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        override public void OnAppearing()
        {
            Stop = false;
            StopScan();
            StartScan();
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnDisappearing()
        {
            Stop = true;
            StopScan();
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
