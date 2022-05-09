using System;
using FenomPlus.Interfaces;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace FenomPlus.Services
{
    public class CacheService : BaseService, ICacheService
    {
        public CacheService(IAppServices services) : base(services)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool GetDeviceExpiringSoon(int days)
        {
            // determine if confirmed yet 
            if(days <= 60)
            {

            } else {
                AppSettings.AddOrUpdateValue("DeviceExpiringSoon_key", false);              // set if below days
                AppSettings.AddOrUpdateValue("DeviceExpiringSoonConfirmed_key", false);     // set if confirmed
            }
            return AppSettings.GetValueOrDefault("DeviceExpiringSoonConfirmed_key", false);
            //  AppSettings.AddOrUpdateValue("DeviceExpiringSoon_key", value);
        }

        public bool GetDeviceSensorExpiringSoon(int days)
        {
            return AppSettings.GetValueOrDefault("DeviceSensorExpiringConfirmedSoon_key", false);
            //  AppSettings.AddOrUpdateValue("DeviceSensorExpiringSoon_key", value);
        }

        public bool GetDeviceBatteryLow(double voltage)
        {
            return AppSettings.GetValueOrDefault("DeviceBatteryConfirmedLow_key", false);
            //  AppSettings.AddOrUpdateValue("DeviceBatteryLow_key", value);
        }
    }
}

