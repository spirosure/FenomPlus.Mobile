using System;

namespace FenomPlus.Interfaces
{
    public interface ICacheService
    {
        string QCUsername { get; set; }
        bool GetDeviceExpiringSoon(int days);
        bool GetDeviceSensorExpiringSoon(int days);
        bool GetDeviceBatteryLow(double voltage);
    }
}
