using System;
using Xamarin.Forms;

namespace FenomPlus.Models
{
    public class DeviceStatus : BaseModel
    {
        public const int BatteryDeviceLow = 3;
        public const int BatteryDeviceWarning = 20;
        public const int BatteryDeviceFull = 100;
        private SensorStatus batteryDevice;
        public SensorStatus BatteryDevice {
            get => batteryDevice;
            set
            {
                batteryDevice = value;
                OnPropertyChanged("BatteryDevice");
            }
        }

        public const int DeviceExpirationLow = 0;
        public const int DeviceExpirationWarning = 60;
        public const int DeviceExpirationFull = 5 * 365 + 10;
        private SensorStatus deviceExpiration;
        public SensorStatus DeviceExpiration
        {
            get => deviceExpiration;
            set
            {
                deviceExpiration = value;
                OnPropertyChanged("DeviceExpiration");
            }
        }

        public const int SensoryExpirationLow = 0;
        public const int SensoryExpirationWarning = 60;
        public const int SensoryExpirationFull = 1 * 365 + 10;
        private SensorStatus sensoryExpiration;
        public SensorStatus SensoryExpiration
        {
            get => sensoryExpiration;
            set
            {
                sensoryExpiration = value;
                OnPropertyChanged("SensoryExpiration");
            }
        }

        public const int QualityControlExpirationLow = 0;
        public const int QualityControlExpirationWarning = 1;
        public const int QualityControlExpirationFull = 7;
        private SensorStatus qualityControlExpiration;
        public SensorStatus QualityControlExpiration
        {
            get => qualityControlExpiration;
            set
            {
                qualityControlExpiration = value;
                OnPropertyChanged("QualityControlExpiration");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DeviceStatus()
        {
            BatteryDevice = new SensorStatus();
            DeviceExpiration = new SensorStatus();
            SensoryExpiration = new SensorStatus();
            QualityControlExpiration = new SensorStatus();

            UpdateBatteryDevice(BatteryDevice.RawValue);
            UpdateDeviceExpiration(DeviceExpiration.RawValue);
            UpdateSensoryExpiration(SensoryExpiration.RawValue);
            UpdateQualityControlExpiration(QualityControlExpiration.RawValue);
        }

        /// <summary>
        /// 
        /// </summary>
        public SensorStatus UpdateBatteryDevice(int value)
        {
            BatteryDevice.Title = "Battery Device";
            BatteryDevice.Value = string.Format("{0}%", value);
            BatteryDevice.Type = "CHARGE";
            BatteryDevice.Description = string.Format("{0} tests remaining", value);
            
            if (value <= BatteryDeviceLow) {
                // low
                BatteryDevice.ImageName = "BatteryLow";
                BatteryDevice.Description = "No tests remaining";
                BatteryDevice.Color = Color.Red;
            } else if (value <= BatteryDeviceWarning) {
                // Warning
                BatteryDevice.ImageName = "BatteryWarning";
                BatteryDevice.Color = Color.Orange;
            } else {
                // full
                BatteryDevice.ImageName = "BatteryFull";
                BatteryDevice.Color = Color.Green;
            }
            BatteryDevice.Image = BatteryDevice.ImageName;
            OnPropertyChanged("BatteryDevice");
            return BatteryDevice;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public SensorStatus UpdateDeviceExpiration(int value)
        {
            DeviceExpiration.Title = "Device Expiration";
            DeviceExpiration.Description = "Remaining";
            if (value <= DeviceExpirationLow) {
                // low
                DeviceExpiration.ImageName = "DeviceLow";
                DeviceExpiration.Color = Color.Red;
            } else if (value <= DeviceExpirationWarning) {
                // Warning
                DeviceExpiration.ImageName = "DeviceWarning";
                DeviceExpiration.Color = Color.Orange;
            } else {
                // full
                DeviceExpiration.ImageName = "DeviceFull";
                DeviceExpiration.Color = Color.Green;
            }
            DeviceExpiration.Image = DeviceExpiration.ImageName;
            DeviceExpiration.Value = string.Format("{0}", (int)((value < 365) ? value : value / 365));
            DeviceExpiration.Type = (value < 365) ? ((value != 1) ? "DAYS" : "DAY") : "YEARS";
            OnPropertyChanged("DeviceExpiration");
            return deviceExpiration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public SensorStatus UpdateSensoryExpiration(int value)
        {
            SensoryExpiration.Title = "Sensory Expiration";
            SensoryExpiration.Description = "Remaining";
            if (value <= SensoryExpirationLow) {
                // low
                SensoryExpiration.ImageName = "SensorLow";
                SensoryExpiration.Color = Color.Red;
            } else if (value <= SensoryExpirationWarning) {
                // Warning
                SensoryExpiration.ImageName = "SensorWarning";
                SensoryExpiration.Color = Color.Orange;
            } else {
                // full
                SensoryExpiration.ImageName = "SensorFull";
                SensoryExpiration.Color = Color.Green;
            }
            SensoryExpiration.Image = SensoryExpiration.ImageName;
            SensoryExpiration.Type = (value < 365) ? ((value != 1) ? "DAYS" : "DAY") : "YEARS";
            SensoryExpiration.Value = string.Format("{0}", (int)((value < 365) ? value : value / 365));
            OnPropertyChanged("SensoryExpiration");
            return SensoryExpiration;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public SensorStatus UpdateQualityControlExpiration(int value)
        {
            QualityControlExpiration.Title = "Quality Control Expiration";
            QualityControlExpiration.Description = "Remaining";
            if (value <= QualityControlExpirationLow) {
                // low
                QualityControlExpiration.ImageName = "QualityControlAlert";
                QualityControlExpiration.Color = Color.Red;
            } else if (value <= QualityControlExpirationWarning) {
                // Warning
                QualityControlExpiration.ImageName = "QualityControlWarning";
                QualityControlExpiration.Color = Color.Orange;
            } else {
                // full
                QualityControlExpiration.ImageName = "QualityControlFull";
                QualityControlExpiration.Color = Color.Green;
            }
            QualityControlExpiration.Image = QualityControlExpiration.ImageName;
            QualityControlExpiration.Type = (value < 365) ? ((value != 1) ? "DAYS" : "DAY") : "YEARS";
            QualityControlExpiration.Value = string.Format("{0}", (int)((value < 365) ? value : value / 365));
            OnPropertyChanged("QualityControlExpiration");
            return qualityControlExpiration;
        }
    }
}
