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

        Task EnableMonitorAsync(Action<byte[]> callback);
        Task DisableMonitorAsync();
        Task<byte[]> ReadAsync();
        Task<bool> WriteAsync(byte[] value);
        Task WriteWithoutResponseAsync(byte[] value);
    }
}
