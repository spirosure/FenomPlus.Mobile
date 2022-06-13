using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FenomPlus.SDK.Core.Ble.Interface;
using Microsoft.Extensions.Logging;

namespace FenomPlus.SDK.Abstractions
{
    public interface IFenomHubSystemDiscovery
    {
        IFenomHubSystem FenomHubSystem { get; set; }
        void SetLoggerFactory(ILoggerFactory loggerFactory);
        bool IsScanning { get; }
        Task<IEnumerable<IFenomHubSystem>> Scan(TimeSpan scanTime = default, Action<IBleDevice> deviceFoundCallback = null, Action<IEnumerable<IBleDevice>> scanCompletedCallback = null);
        Task<bool> StopScan();
    }
}