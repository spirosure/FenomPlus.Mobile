using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FenomPlus.SDK.Abstractions;
using FenomPlus.SDK.Core.Ble.Interface;
using FenomPlus.SDK.Core.Models;

namespace FenomPlus.Interfaces
{
    public interface IBleHubService
    {
        Task<bool> Connect(IBleDevice bleDevice);
        Task<bool> Disconnect(IBleDevice bleDevice = null);

        bool IsConnected();

        Task<bool> StartTest(BreathTestEnum breathTestEnum);
        Task<bool> StopTest();
        Task<bool> RequestDeviceInfo();
        Task<bool> RequestEnvironmentalInfo();

        Task<IEnumerable<IFenomHubSystem>> Scan(TimeSpan scanTime = default, Action<IBleDevice> deviceFoundCallback = null, Action<IEnumerable<IBleDevice>> scanCompletedCallback = null);
        Task<bool> StopScan();
    }
}
