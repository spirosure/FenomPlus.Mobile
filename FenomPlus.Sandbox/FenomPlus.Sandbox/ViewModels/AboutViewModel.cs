using System;
using System.Collections.Generic;
using System.Windows.Input;
using FenomPlus.Sandbox.Helpers;
using FenomPlus.SDK.Abstractions;
using FenomPlus.SDK.Core;
using FenomPlus.SDK.Core.Ble.Interface;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.ViewModels
{
    public class DeviceFound
    {
        public IBleDevice Device { get; set; }
        public Color BgColor
        {
            get
            {
                /*
                if (Device.Rssi > -40) return Color.LightBlue;
                if (Device.Rssi > -50) return Color.LightGreen;
                if (Device.Rssi > -60) return Color.LightYellow;
                if (Device.Rssi > -70) return Color.LightSalmon;
                if (Device.Rssi > -80) return Color.LightSlateGray;
                return Color.Red;
                */
                return Color.Transparent;
            }
        }
    }

    public class AboutViewModel : BaseViewModel
    {
        IFenomHubSystemDiscovery fenomHubSystemDiscovery;
        public RangeObservableCollection<DeviceFound> Items { get; set; }

        public AboutViewModel()
        {
            Title = "Scan";
            Items = new RangeObservableCollection<DeviceFound>();
            Enabled = true;

            ScanCommand = new Command(() =>
            {
                StartScan();
            });

            fenomHubSystemDiscovery = new FenomHubSystemDiscovery();
            fenomHubSystemDiscovery.SetLoggerFactory(App.loggerFactory);
        }

        /// <summary>
        /// exmaple to continue the scan
        /// </summary>
        public void StartScan()
        {
            Enabled = false;
            Items.Clear();
            fenomHubSystemDiscovery.Scan(new TimeSpan(0, 0, 0, 10), (IBleDevice bleDevice) =>
            {
                if ((bleDevice != null) && !string.IsNullOrEmpty(bleDevice.Name))
                {
                    int index = 0;
                    DeviceFound record;
                    while (index < Items.Count)
                    {
                        record = Items[index];
                        if (record.Device.Name == bleDevice.Name)
                        {
                            record.Device = bleDevice;
                            Items.SendNotifications();
                            return;
                        }
                        index++;
                    }
                    Items.Add(new DeviceFound() { Device = bleDevice });
                }
            }, (IEnumerable<IBleDevice> bleDevices) =>
            {
                Enabled = true;
                //StartScan();
            });
        }

        public ICommand ScanCommand { get; }

        public void OnAppearing()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private bool enabled;
        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                OnPropertyChanged("Enabled");
            }
        }
    }
}