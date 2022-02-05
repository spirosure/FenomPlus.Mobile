using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FenomPlus.SDK.Core.Features;
using FenomPlus.SDK.Core.Models.Command;

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
        Task<bool> EnsureConnected();
        Task<int> UpdatedRssi();
        Task<IGattCharacteristic> GetCharacterasticsAync(Guid gattCharacteristicUuid);
        Task<IGattCharacteristic> GetCharacterasticsAync(string gattCharacteristicUuid);

        // used for queuing
        Guid Subscribe(IBleDevice subscriber, Action<IBleDevice, byte[], CommandPacket> callBack = null);
        void UnSubscribe(Guid token);

        // add features for device here
    }
}
