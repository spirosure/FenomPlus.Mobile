using System;

namespace FenomPlus.Database.Tables
{
    public class QualityControlDevicesTb : BaseTb<QualityControlDevicesTb>
    {
        public string SerialNumber { get; set; }
        public DateTime LastConnected { get; set; }
    }
}
