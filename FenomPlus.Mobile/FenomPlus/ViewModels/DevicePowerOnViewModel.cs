﻿using System;
using System.Collections.Generic;
using FenomPlus.SDK.Core.Ble.Interface;
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
            App.BleDevice?.DisconnectAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartScan()
        {
            // if scanning then stop the scan
            App.BleDevice = null;
            Seconds = App.ScanSeconds;
            Device.StartTimer(TimeSpan.FromSeconds(1), TimerCallback);
            FenomHub.Scan(new TimeSpan(0, 0, 0, App.ScanSeconds), (IBleDevice bleDevice) =>
            {
                if ((bleDevice != null) && !string.IsNullOrEmpty(bleDevice.Name) && (App.BleDevice == null))
                {
                    App.BleDevice = bleDevice;
                    FenomHub.StopScan();
                    App.BleDevice.ConnectAsync();
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
            if (Stop == true) seconds = 0;
            // conenct  here
            if ((App.BleDevice != null) && (App.BleDevice.Connected))
            {
                // ok time to wait for connection and goto next page
                Device.BeginInvokeOnMainThread(() =>
                {



                });
            }
            return (Seconds > 0);
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
        public void OnAppearing()
        {
            Stop = false;
            StopScan();
            StartScan();
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnDisappearing()
        {
            Stop = true;
            StopScan();            
        }
    }
}
