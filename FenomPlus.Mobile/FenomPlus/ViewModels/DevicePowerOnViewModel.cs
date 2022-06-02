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
            FenomHub.StopScan();
            if ((App.BleDevice != null) && (App.BleDevice.Connected == false))
            {
                App.BleDevice?.DisconnectAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartScan()
        {
            // if scanning then stop the scan
            _ = App.DisconnectDevice();
            App.BleDevice = null;
            //
            Seconds = App.ScanSeconds;
            Device.StartTimer(TimeSpan.FromSeconds(1), TimerCallback);
            _ = FenomHub.Scan(new TimeSpan(0, 0, 0, App.ScanSeconds), async (IBleDevice bleDevice) =>
              {
                  if ((bleDevice != null) && !string.IsNullOrEmpty(bleDevice.Name) && (App.BleDevice == null))
                  {
                      FenomHub.StopScan();
                      Device.BeginInvokeOnMainThread(async () =>
                      {
                          var connected = await bleDevice.ConnectAsync();
                          if (connected == true)
                          {
                              App.BleDevice = bleDevice;
                              Stop = true;
                              await Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(DeviceReadyView)}"), false);
                          }
                      });
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
            /*
            if(Seconds > 0) Seconds--;
            if ((App.BleDevice != null) && (App.BleDevice.Connected))
            {
                // ok time to wait for connection and goto next page
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Shell.Current.GoToAsync(new ShellNavigationState("DeviceReadyView"), false);
                });
                return false;
            }
            */
            if (Seconds <= 0)
            {
                _ = App.DisconnectDevice();
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
                Message = string.Format("Device is Ready in {0} Seconds", seconds);
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

    }
}
