using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FenomPlus.SDK.Core.Ble.Interface
{
    public interface IBleDevice
    {
        string Name { get; }
        int? Rssi { get; }
        string Manufacturer { get; }
        string Model { get; }
        string HardwareVersion { get; }
        string SoftwareVersion { get; }
        string SerialNumber { get; }
        object NativeDevice { get; }
        Guid Uuid { get; }
        bool IsBonded { get; }
        bool Connected { get; }
        IEnumerable<IGattCharacteristic> GattCharacteristics { get; }
        Task<bool> ConnectAsync();
        Task DisconnectAsync();
    }
}
