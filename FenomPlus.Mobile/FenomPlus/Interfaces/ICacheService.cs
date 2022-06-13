using System;
using FenomPlus.Models;
using FenomPlus.SDK.Core.Models;
using Microsoft.Extensions.Logging;

namespace FenomPlus.Interfaces
{
    public interface ICacheService
    {
        ILoggerFactory Logger { get; set; }
        string QCUsername { get; set; }
        bool GetDeviceExpiringSoon(int days);
        bool GetDeviceSensorExpiringSoon(int days);
        bool GetDeviceBatteryLow(double voltage);

        string DeviceSerialNumber { get; set; }
        TestTypeEnum TestType { get; set; }
        int ReadBreathData { get; set; }
                                         
        EnvironmentalInfo _EnvironmentalInfo { get; set; }
        BreathManeuver _BreathManeuver { get; set; }
        DeviceInfo _DeviceInfo { get; set; }
        DebugMsg _DebugMsg { get; set; }
    }
}
