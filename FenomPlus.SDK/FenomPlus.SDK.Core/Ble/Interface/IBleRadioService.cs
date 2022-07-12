using Plugin.BLE.Abstractions.EventArgs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FenomPlus.SDK.Core.Ble.Interface
{
    public interface IBleRadioService
    {
        bool IsScanning { get; }

        IEnumerable<IBleDevice> Devices { get; }
        IEnumerable<IBleDevice> BondedDevices { get; }
        Task<bool> Scan(double scanTime, bool scanBondedDevices, bool scanBleDevices, Action<IBleDevice> deviceFoundCallback = null, Action<IEnumerable<IBleDevice>> scanCompletedCallback = null, Action scanTimeoutCallback = null);
        Task<bool> StopScan();

        event EventHandler<DeviceEventArgs> DeviceAdvertised;
        event EventHandler<DeviceEventArgs> DeviceDiscovered;
        event EventHandler<DeviceEventArgs> DeviceConnected;
        event EventHandler<DeviceEventArgs> DeviceDisconnected;
        event EventHandler<DeviceErrorEventArgs> DeviceConnectionLost;
    }
}
