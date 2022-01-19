using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FenomPlus.SDK.Core.Ble.Interface;

namespace FenomPlus.Core.Interfaces.Ble
{
    public interface IBleHubProviderService
    {
        Task<bool> Connect(IBleDevice bleDevice);
        Task<bool> Scan(Action<IBleDevice> deviceFoundCallback = null, Action<IEnumerable<IBleDevice>> scanCompletedCallback = null);
        Task<bool> Disconnect(IBleDevice bleDevice);

        Task<bool> IsConnected(IBleDevice bleDevice = null, Action<IEnumerable<IBleDevice>> completed = null);
        Task<bool> Feature(IBleDevice bleDevice = null, Action<IEnumerable<IBleDevice>> completed);
    }
}
