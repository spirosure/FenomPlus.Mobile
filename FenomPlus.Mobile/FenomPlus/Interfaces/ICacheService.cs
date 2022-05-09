using System;

namespace FenomPlus.Interfaces
{
    public interface ICacheService
    {
        bool GetDeviceExpiringSoon(int days);
        bool GetDeviceSensorExpiringSoon(int days);
        bool GetDeviceBatteryLow(double voltage);
    }
}
