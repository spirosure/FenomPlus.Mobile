using System;
using System.Text;
using FenomPlus.Interfaces;
using FenomPlus.Models;
using FenomPlus.SDK.Core.Models;
using Microsoft.Extensions.Logging;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace FenomPlus.Services
{
    public class CacheService : BaseService, ICacheService
    {
        public CacheService(IAppServices services) : base(services)
        {
            ReadBreathData = 200;
            DeviceSerialNumber = "F150-1234567";

            Logger = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Debug)
                    .AddFilter("FenomPlus", LogLevel.Debug);
            });

            _EnvironmentalInfo = new EnvironmentalInfo();
            _BreathManeuver = new BreathManeuver();
            _DeviceInfo = new DeviceInfo();
            _DebugMsg = new DebugMsg();
        }

        public ILoggerFactory Logger { get; set; }

        public string DeviceSerialNumber { get; set; }
        public TestTypeEnum TestType { get; set; }
        public int ReadBreathData { get; set; }

        public EnvironmentalInfo _EnvironmentalInfo { get; private set; }
        public BreathManeuver _BreathManeuver { get; private set; }
        public DeviceInfo _DeviceInfo { get; private set; }
        public DebugMsg _DebugMsg { get; private set; }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public bool GetDeviceSensorExpiringSoon(int days)
        {
            return AppSettings.GetValueOrDefault("DeviceSensorExpiringConfirmedSoon_key", false);
            //  AppSettings.AddOrUpdateValue("DeviceSensorExpiringSoon_key", value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voltage"></param>
        /// <returns></returns>
        public bool GetDeviceBatteryLow(double voltage)
        {
            return AppSettings.GetValueOrDefault("DeviceBatteryConfirmedLow_key", false);
            //  AppSettings.AddOrUpdateValue("DeviceBatteryLow_key", value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string QCUsername { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialNumber"></param>
        public string SetDeviceSerialNumber(byte[] serialNumber)
        {
            if ((serialNumber != null) && (serialNumber.Length > 0))
            {
                DeviceSerialNumber = Encoding.Default.GetString(serialNumber);
            }
            return DeviceSerialNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public EnvironmentalInfo DecodeEnvironmentalInfo(byte[] data)
        {
            _EnvironmentalInfo.Decode(data);

            NotifyViews();
            NotifyViewModels();
            return _EnvironmentalInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BreathManeuver DecodeBreathManeuver(byte[] data)
        {
            _BreathManeuver.Decode(data);

            NotifyViews();
            NotifyViewModels();
            return _BreathManeuver;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DeviceInfo DecodeDeviceInfo(byte[] data)
        {
            _DeviceInfo.Decode(data);

            SetDeviceSerialNumber(_DeviceInfo.SerialNumber);

            NotifyViews();
            NotifyViewModels();
            return _DeviceInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DebugMsg DecodeDebugMsg(byte[] data)
        {
            _DebugMsg.Decode(data);
            Services.DebugLogFile.Write(data);
            NotifyViews();
            NotifyViewModels();
            return _DebugMsg;
        }

        /// <summary>
        /// 
        /// </summary>
        private void NotifyViews()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private void NotifyViewModels()
        {
        }

    }
}

