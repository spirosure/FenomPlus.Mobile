using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using FenomPlus.Sandbox.Helpers;
using FenomPlus.SDK.Core.Ble.Interface;
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
                if (Device.Rssi > -40) return Color.LightBlue;
                if (Device.Rssi > -50) return Color.LightGreen;
                if (Device.Rssi > -60) return Color.LightYellow;
                if (Device.Rssi > -70) return Color.LightSalmon;
                if (Device.Rssi > -80) return Color.LightSlateGray;
                return Color.Red;
            }
        }
    }

    public class ScanBleViewModel : BaseViewModel
    {
        public RangeObservableCollection<DeviceFound> Items { get; set; }

        public ScanBleViewModel()
        {
            Title = "Scan";
            Items = new RangeObservableCollection<DeviceFound>();
            Enabled = true;

            ScanCommand = new Command(() =>
            {
                StartScan();
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public void StopScan()
        {
            FenomHub.StopScan();
            _ = App.DisconnectDevice();
        }

        /// <summary>
        /// exmaple to continue the scan
        /// </summary>
        public void StartScan(bool continueScan = false)
        {
            // if scanning then stop the scan
            StopScan();
            Enabled = false;
            if (!continueScan)
            {
                Items.Clear();
            }
            FenomHub.Scan(new TimeSpan(0, 0, 0, App.ScanSeconds), (IBleDevice bleDevice) =>
            {
                if ((bleDevice != null) && !string.IsNullOrEmpty(bleDevice.Name))
                {
                    if (continueScan)
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
                    }
                    Items.Add(new DeviceFound() { Device = bleDevice });
                }
            }, (IEnumerable<IBleDevice> bleDevices) =>
            {
                Enabled = true;
                if (continueScan)
                {
                    StartScan(continueScan);
                } else {
                }
            });
        }

        public ICommand ScanCommand { get; }

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

        public void OnAppearing()
        {
        }

        public void OnDisappearing()
        {
        }
    }
}