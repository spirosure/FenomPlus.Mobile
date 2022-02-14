﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FenomPlus.SDK.Core.Ble.Interface;

namespace FenomPlus.Interfaces
{
    public interface IBleHubService
    {
        Task<bool> Connect(string serial);
        Task<bool> Connect(IBleDevice bleDevice);
        Task<bool> Scan(Action<IBleDevice> deviceFoundCallback = null, Action<IEnumerable<IBleDevice>> scanCompletedCallback = null);
        Task<bool> Disconnect(IBleDevice bleDevice = null);

        // add functions / features here
        Task<bool> IsConnected(IBleDevice bleDevice = null, Action<IEnumerable<IBleDevice>> completed = null);
        Task<bool> Feature(IBleDevice bleDevice = null, Action<IEnumerable<IBleDevice>> completed = null);
        bool IsStateOn { get; set; }
    }
}