using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FenomPlus.Interfaces;
using FenomPlus.SDK.Abstractions;
using FenomPlus.SDK.Core;
using FenomPlus.SDK.Core.Ble.Interface;
using FenomPlus.SDK.Core.Features;
using FenomPlus.SDK.Core.Models;
using FenomPlus.Views;
using Xamarin.Forms;

namespace FenomPlus.Services
{
    public class BleHubService : BaseService, IBleHubService
    {
        public BleHubService(IAppServices services) : base(services)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private IBleDevice BleDevice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private IFenomHubSystemDiscovery fenomHubSystemDiscovery;
        protected  IFenomHubSystemDiscovery FenomHubSystemDiscovery
        {
            get
            {
                if (fenomHubSystemDiscovery == null)
                {
                    fenomHubSystemDiscovery = new FenomHubSystemDiscovery();
                    fenomHubSystemDiscovery.SetLoggerFactory(Services.Cache.Logger);
                }
                return fenomHubSystemDiscovery;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> StopScan()
        {
            return await FenomHubSystemDiscovery.StopScan();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scanTime"></param>
        /// <param name="deviceFoundCallback"></param>
        /// <param name="scanCompletedCallback"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IFenomHubSystem>> Scan(TimeSpan scanTime = default, bool scanBondedDevices = true, bool scanBleDevices = true, Action<IBleDevice> deviceFoundCallback = null, Action<IEnumerable<IBleDevice>> scanCompletedCallback = null)
        {
            return await FenomHubSystemDiscovery.Scan(scanTime, scanBondedDevices, scanBleDevices, deviceFoundCallback, scanCompletedCallback);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bleDevice"></param>
        /// <returns></returns>
        public async Task<bool> Connect(IBleDevice bleDevice)
        {
            await Disconnect();
            BleDevice = bleDevice;
            return await bleDevice.ConnectAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bleDevice"></param>
        /// <returns></returns>
        public async Task<bool> Disconnect()
        {
            if (BleDevice != null)
            {
                if (BleDevice.Connected == true)
                {
                    await BleDevice.DisconnectAsync();
                    BleDevice = null;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bleDevice"></param>
        /// <param name="completed"></param>
        /// <returns></returns>
        public bool IsConnected(bool devicePowerOn = false)
        {
            // do we have a device
            if(BleDevice != null)
            {
                // if disconnected try to re-conenct
                if(BleDevice.Connected == false)
                {
                    // try to connect
                    BleDevice.ConnectAsync();
                }

                // if still disconnect go back to power on screen
                if(BleDevice.Connected == true)
                {
                    return BleDevice.Connected;
                }
            }
            Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(DevicePowerOnView)}"), false);
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="breathTestEnum"></param>
        /// <returns></returns>
        public async Task<bool> StartTest(BreathTestEnum breathTestEnum)
        {
            if(IsConnected())
            {
                return await BleDevice.BREATHTEST(breathTestEnum);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> StopTest()
        {
            if (IsConnected())
            {
                return await BleDevice.BREATHTEST(BreathTestEnum.Stop);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RequestDeviceInfo()
        {
            if (IsConnected())
            {
                return await BleDevice.DEVICEINFO();
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RequestEnvironmentalInfo()
        {
            if (IsConnected())
            {
                return await BleDevice.ENVIROMENTALINFO();
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<bool> SendMessage(MESSAGE message)
        {
            if (IsConnected())
            {
                return await BleDevice.MESSAGE(message);
            }
            return false;
        }


    }
}
