using System;
using System.Runtime.InteropServices;

namespace FenomPlus.SDK.Core.Models.Characteristic
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DeviceInfo
    {
        public byte DeviceStatus;
        public byte MajorVersion;
        public byte MinorVersion;
        public byte BuildVersion;
        public byte SensorExpDateMonth; 
        public byte SensorExpDateDay;
        public short SensorExpDateYear;
        public byte BatteryLevel;
    }
}
