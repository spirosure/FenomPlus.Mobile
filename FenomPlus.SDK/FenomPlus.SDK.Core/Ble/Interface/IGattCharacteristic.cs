using System;
using System.Threading.Tasks;

namespace FenomPlus.SDK.Core.Ble.Interface
{
    public interface IGattCharacteristic
    {
        Guid Uuid { get; }
        Task<byte[]> ReadAsync();
        Task<bool> WriteAsync(byte[] value);
        Task<bool> WriteWithoutResponseAsync(byte[] value);
    }
}
