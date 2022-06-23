using System;
using FenomPlus.Helpers;
using FenomPlus.Models;
using FenomPlus.SDK.Core.Models;
using Microsoft.Extensions.Logging;

namespace FenomPlus.Interfaces
{
    public interface ICacheService
    {
        ILoggerFactory Logger { get; set; }
        string QCUsername { get; set; }

        bool DeviceExpiring { get; set; }
        bool DeviceSensorExpiring { get; set; }
        bool BatteryStatus { get; set; }

        int BatteryLevel { get; set; }
        DateTime SensorExpireDate { get; set; }
        string DeviceSerialNumber { get; set; }
        string Firmware { get; set; }
        TestTypeEnum TestType { get; set; }
        int ReadBreathData { get; set; }

        RangeObservableCollection<string> DebugList { get; set; }
        EnvironmentalInfo _EnvironmentalInfo { get; }
        BreathManeuver _BreathManeuver { get;  }
        DeviceInfo _DeviceInfo { get;  }
        DebugMsg _DebugMsg { get;  }

        EnvironmentalInfo DecodeEnvironmentalInfo(byte[] data);
        BreathManeuver DecodeBreathManeuver(byte[] data);
        DeviceInfo DecodeDeviceInfo(byte[] data);
        DebugMsg DecodeDebugMsg(byte[] data);
    }
}
