using System;

namespace FenomPlus.Database.Tables
{
    public class DevicesTb : BaseTb<DevicesTb>
    {
        public string SerialNumber { get; set; }
        public DateTime LastConnected { get; set; }
    }
}
