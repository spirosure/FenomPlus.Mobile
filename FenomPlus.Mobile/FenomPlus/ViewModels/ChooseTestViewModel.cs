using System.Windows.Input;
using FenomPlus.Helpers;
using FenomPlus.Models;
using Xamarin.Forms;

namespace FenomPlus.ViewModels
{
    public class ChooseTestViewModel : BaseViewModel
    {
        public ICommand DismissCommand { get; private set; }

        public ChooseTestViewModel()
        {
            DeviceStatus = new DeviceStatus();
            ErrorList = new RangeObservableCollection<Alert>();
            /*
            ErrorList.Add(new Alert()
            {
                Id = 1,
                Description = "Fenom Plus has 6% charge with 2 tests remaining. Please connect your device to the charging port.",
                Image = "BatteryWarning",
                Title = "Device Battery Low"
            });
            ErrorList.Add(new Alert()
            {
                Id = 2,
                Description = "Fenom Plus sensor will expire in 60 days. For information on ordering a replacement sensor and how to replace your sensor, please view online FAQ.",
                Image = "SensorWarning",
                Title = "Device Sensor Expiring Soon"
            });
            ErrorList.Add(new Alert()
            {
                Id = 3,
                Description = "Fenom Plus Device will expire in 60 days. For information on ordering a replacement device, please view online FAQ.",
                Image = "DeviceWarning",
                Title = "Device Expiring Soon"
            });
            */
            UpdateErrorList();

            DismissCommand = new Command<Alert>((model) => {
                foreach(Alert alert in ErrorList)
                {
                    if (model.Id != alert.Id) continue;
                    ErrorList.Remove(alert);
                    break;
                }
                UpdateErrorList();
            });
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnAppearing()
        {
            base.OnAppearing();
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnDisappearing()
        {
            base.OnDisappearing();
        }


        public DeviceStatus DeviceStatus { get; set; }

        public RangeObservableCollection<Alert> ErrorList { get;set; }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateErrorList()
        {
            ErrorHeight = ErrorList.Count * 74;
            ErrorVisable = ErrorHeight > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        private bool errorVisable;
        public bool ErrorVisable
        {
            get => errorVisable;
            set
            {
                errorVisable = value;
                OnPropertyChanged("ErrorVisable");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private int errorHeight;
        public int ErrorHeight
        {
            get => errorHeight;
            set
            {
                errorHeight = value;
                OnPropertyChanged("ErrorHeight");
            }
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
