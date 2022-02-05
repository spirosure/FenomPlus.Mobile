using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FenomPlus.Interfaces;
using FenomPlus.SDK.Core.Ble.Interface;

namespace FenomPlus.Services
{
    public class BleHubService : BaseService, IBleHubService
    {
        public BleHubService()
        {
        }

        public bool IsStateOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<bool> Connect(string serial)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Connect(IBleDevice bleDevice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Disconnect(IBleDevice bleDevice = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Feature(IBleDevice bleDevice = null, Action<IEnumerable<IBleDevice>> completed = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsConnected(IBleDevice bleDevice = null, Action<IEnumerable<IBleDevice>> completed = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Scan(Action<IBleDevice> deviceFoundCallback = null, Action<IEnumerable<IBleDevice>> scanCompletedCallback = null)
        {
            throw new NotImplementedException();
        }
    }
}
