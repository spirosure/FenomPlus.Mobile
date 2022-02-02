using System.Collections.ObjectModel;
using System.Windows.Input;
using FenomPlus.SDK.Core.Ble.Interface;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.ViewModels
{
    public class BleDeviceViewModel : BaseViewModel
    {
        public ObservableCollection<IGattCharacteristic> Items { get; set; }

        public BleDeviceViewModel()
        {
            Title = "Ble Device";
            ToggleLedName = "Led Off";
            if (BleDevice.Connected) {
                EnableButtons();
            } else  {
                DisableButtons();
            }
            Items = new ObservableCollection<IGattCharacteristic>();

            ConnectCommand = new Command(async () =>
            {
                Items.Clear();
                DisableButtons();
                ConnectEnabled = false;
                if (BleDevice.Connected)
                {
                    await BleDevice.DisconnectAsync();
                }

                bool status = await BleDevice.ConnectAsync();
                if (status)
                {
                    EnableButtons();
                    foreach (IGattCharacteristic characteristic in BleDevice.GattCharacteristics) {
                        Items.Add(characteristic);
                    }
                    if(BleDevice.Name.ToUpper().StartsWith("BLINKY  "))
                    {
                        // get led status here
                        // get button status here
                        ToggleLedName = "Led On";
                    }
                } else {
                    DisableButtons();
                }
            });

            DisconnectCommand = new Command(async () =>
            {
                if (BleDevice.Connected)
                {
                    await BleDevice.DisconnectAsync();
                }
                DisableButtons();
                Items.Clear();
            });

            ToggleLedCommand = new Command(async () =>
            {
                if (BleDevice.Connected)
                {
                    int status = UpdateLedStatus();
                    ToggleLedStatus(status);
                    UpdateLedStatus();
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        int ledStatus;
        public void ToggleLedStatus(int status)
        {
            ledStatus = (status > 0) ? 0x00 : 0x01;
            // write statuss to gatt here
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int UpdateLedStatus()
        {
            // call gatt
            // bool ledStatus = true;

            if (ledStatus > 0)
            {
                ToggleLedName = "Led On";
                return 0x01;
            }
            else
            {
                ToggleLedName = "Led Off";
                return 0x00;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void EnableButtons()
        {
            ConnectEnabled = false;
            DisconnectEnabled = true;
            ToggleLedEnabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DisableButtons()
        {
            ConnectEnabled = true;
            DisconnectEnabled = false;
            ToggleLedEnabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get => BleDevice.Name;
        }

        public ICommand ConnectCommand { get; }
        public ICommand DisconnectCommand { get; }
        public ICommand ToggleLedCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        private bool connectEnabled;
        public bool ConnectEnabled
        {
            get => connectEnabled;
            set
            {
                connectEnabled = value;
                OnPropertyChanged("ConnectEnabled");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool disconnectEnabled;
        public bool DisconnectEnabled
        {
            get => disconnectEnabled;
            set
            {
                disconnectEnabled = value;
                OnPropertyChanged("DisconnectEnabled");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool toggleLedEnabled;
        public bool ToggleLedEnabled
        {
            get => toggleLedEnabled;
            set
            {
                toggleLedEnabled = value;
                OnPropertyChanged("ToggleLedEnabled");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool buttonPressedEnabled;
        public bool ButtonPressedEnabled
        {
            get => buttonPressedEnabled;
            set
            {
                buttonPressedEnabled = value;
                OnPropertyChanged("ButtonPressedEnabled");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string toggleLedName;
        public string ToggleLedName
        {
            get => toggleLedName;
            set
            {
                toggleLedName = value;
                OnPropertyChanged("ToggleLedName");
            }
        }
        
    }
}