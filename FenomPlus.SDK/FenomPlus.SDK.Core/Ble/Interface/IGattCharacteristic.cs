using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FenomPlus.SDK.Core.Ble.Interface
{
    public interface IGattCharacteristic
    {
        Guid Uuid { get; }
        string Description { get; }
        bool IsNotifying { get; }

        Task<bool> EnableMonitorAsync(Action<byte[]> callback);
        Task<bool> DisableMonitorAsync();
        Task<byte[]> ReadAsync();
        Task<bool> WriteAsync(byte[] value);
        Task<bool> WriteWithoutResponseAsync(byte[] value);
    }
}
