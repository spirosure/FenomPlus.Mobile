using System;
using Xamarin.Forms;

namespace FenomPlus.Models
{
    public class DeviceStatus : BaseModel
    {
        public const int BatteryDeviceLow = 1;
        public const int BatteryDeviceWarning = 6;
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

        public DeviceStatus()
        {
            BatteryDevice = new SensorStatus();
            DeviceExpiration = new SensorStatus();
            SensoryExpiration = new SensorStatus();
            QualityControlExpiration = new SensorStatus();

            int x = 2; // for testing only

            // full
            if (x == 0)
            {
                BatteryDevice.RawValue = BatteryDeviceFull;
                DeviceExpiration.RawValue = DeviceExpirationFull;
                SensoryExpiration.RawValue = SensoryExpirationFull;
                QualityControlExpiration.RawValue = QualityControlExpirationFull;
            }

            // Warning
            if (x == 1)
            {
                BatteryDevice.RawValue = BatteryDeviceWarning;
                DeviceExpiration.RawValue = DeviceExpirationWarning;
                SensoryExpiration.RawValue = SensoryExpirationWarning;
                QualityControlExpiration.RawValue = QualityControlExpirationWarning;
            }

            // low
            if (x == 2)
            {
                BatteryDevice.RawValue = BatteryDeviceLow;
                DeviceExpiration.RawValue = DeviceExpirationLow;
                SensoryExpiration.RawValue = SensoryExpirationLow;
                QualityControlExpiration.RawValue = QualityControlExpirationLow;
            }

            UpdateBatteryDevice(BatteryDevice.RawValue);
            UpdateDeviceExpiration(DeviceExpiration.RawValue);
            UpdateSensoryExpiration(SensoryExpiration.RawValue);
            UpdateQualityControlExpiration(QualityControlExpiration.RawValue);
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateBatteryDevice(int value)
        {
            BatteryDevice.Title = "Battery Device";
            BatteryDevice.Value = string.Format("{0}%", value);
            BatteryDevice.Type = "CHARGE";
            BatteryDevice.Description = string.Format("{0} tests remaining", value);
            
            if (value <= BatteryDeviceLow) {
                // low
                BatteryDevice.Image = "BatteryLow";
                BatteryDevice.Description = "No tests remaining";
                BatteryDevice.Color = Color.Red;
            } else if (value <= BatteryDeviceWarning) {
                // Warning
                BatteryDevice.Image = "BatteryWarning";
                BatteryDevice.Color = Color.Orange;
            } else {
                // full
                BatteryDevice.Image = "BatteryFull";
                BatteryDevice.Color = Color.Green;
            }
            OnPropertyChanged("BatteryDevice");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void UpdateDeviceExpiration(int value)
        {
            DeviceExpiration.Title = "Device Expiration";
            DeviceExpiration.Description = "Remaining";
            if (value <= DeviceExpirationLow) {
                // low
                DeviceExpiration.Image = "DeviceLow";
                DeviceExpiration.Color = Color.Red;
            } else if (value <= DeviceExpirationWarning) {
                // Warning
                DeviceExpiration.Image = "DeviceWarning";
                DeviceExpiration.Color = Color.Orange;
            } else {
                // full
                DeviceExpiration.Image = "DeviceFull";
                DeviceExpiration.Color = Color.Green;
            }
            DeviceExpiration.Value = string.Format("{0}", (int)((value < 365) ? value : value / 365));
            DeviceExpiration.Type = (value < 365) ? ((value != 1) ? "DAYS" : "DAY") : "YEARS";
            OnPropertyChanged("DeviceExpiration");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void UpdateSensoryExpiration(int value)
        {
            SensoryExpiration.Title = "Sensory Expiration";
            SensoryExpiration.Description = "Remaining";
            if (value <= SensoryExpirationLow) {
                // low
                SensoryExpiration.Image = "SensorLow";
                SensoryExpiration.Color = Color.Red;
            } else if (value <= SensoryExpirationWarning) {
                // Warning
                SensoryExpiration.Image = "SensorWarning";
                SensoryExpiration.Color = Color.Orange;
            } else {
                // full
                SensoryExpiration.Image = "SensorFull";
                SensoryExpiration.Color = Color.Green;
            }
            SensoryExpiration.Type = (value < 365) ? ((value != 1) ? "DAYS" : "DAY") : "YEARS";
            SensoryExpiration.Value = string.Format("{0}", (int)((value < 365) ? value : value / 365));
            OnPropertyChanged("SensoryExpiration");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void UpdateQualityControlExpiration(int value)
        {
            QualityControlExpiration.Title = "Quality Control Expiration";
            QualityControlExpiration.Description = "Remaining";
            if (value <= QualityControlExpirationLow) {
                // low
                QualityControlExpiration.Image = "QualityControlAlert";
                QualityControlExpiration.Color = Color.Red;
            } else if (value <= QualityControlExpirationWarning) {
                // Warning
                QualityControlExpiration.Image = "QualityControlWarning";
                QualityControlExpiration.Color = Color.Orange;
            } else {
                // full
                QualityControlExpiration.Image = "QualityControlFull";
                QualityControlExpiration.Color = Color.Green;
            }
            QualityControlExpiration.Type = (value < 365) ? ((value != 1) ? "DAYS" : "DAY") : "YEARS";
            QualityControlExpiration.Value = string.Format("{0}", (int)((value < 365) ? value : value / 365));
            OnPropertyChanged("QualityControlExpiration");
        }
    }
}
