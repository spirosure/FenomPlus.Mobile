using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FenomPlus.SDK.Abstractions;
using FenomPlus.SDK.Core.Ble.Interface;
using FenomPlus.SDK.Core.Ble.PluginBLE;
using FenomPlus.SDK.Core.Utils;
using Microsoft.Extensions.Logging;
using Plugin.BLE.Abstractions.EventArgs;

namespace FenomPlus.SDK.Core
{
    public class FenomHubSystemDiscovery : IFenomHubSystemDiscovery
    {
        private FenomHubSystemLost _FenomHubSystemLost;

        private LoggingManager _loggingMaager;
        private Logger _logger;
        private IFenomHubSystem _FenomHubSystem;
        private readonly IBleRadioService _bleRadio;

        public event FenomHubSystemLost FenomHubSystemLostEvent;

        /// <summary>
        /// 
        /// </summary>
        public FenomHubSystemDiscovery()
        {
            PerformanceLogger.StartLog(typeof(FenomHubSystemDiscovery), "FenomHubSystemDiscovery");
            _bleRadio = new BleRadioService();
            _bleRadio.DeviceConnectionLost += DeviceConnectionLost;
            _loggingMaager = LoggingManager.GetInstance;
            _logger = new Logger("FenomBLE");
            PerformanceLogger.EndLog(typeof(FenomHubSystemDiscovery), "FenomHubSystemDiscovery");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceConnectionLost(object sender, DeviceErrorEventArgs e)
        {
            //_FenomHubSystem?.RemoveDeviceAndUpdate(e.Device);
        }

        /// <summary>
        /// 
        /// </summary>
        public IFenomHubSystem FenomHubSystem
        {
            get => _FenomHubSystem;
            set => _FenomHubSystem = value as IFenomHubSystem;
        }

        /// <summary>
        /// SetLoggerFactory
        /// </summary>
        public void SetLoggerFactory(ILoggerFactory loggerFactory)
        {
            _loggingMaager.SetLoggingFactory(loggerFactory);
        }

        /// <summary>
        /// IsScanning
        /// </summary>
        public bool IsScanning => _bleRadio.IsScanning;

        /// <summary>
        /// HFenomHubSystemLost
        /// </summary>
        public event FenomHubSystemLost HFenomHubSystemLostEvent
        {
            add => _FenomHubSystemLost += value;
            remove => _FenomHubSystemLost -= value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IFenomHubSystem Connect()
        {
            //FenomHubSystem = AsyncHelper.RunSync(() => _bleRadio.Connect());
            return FenomHubSystem;
        }

        /// <summary>
        /// Scan
        /// </summary>
        public Task<IEnumerable<IFenomHubSystem>> Scan(TimeSpan scanTime = default, Action<IBleDevice> deviceFoundCallback = null, Action<IEnumerable<IBleDevice>> scanCompletedCallback = null)
        {
            try
            {
                PerformanceLogger.StartLog(typeof(FenomHubSystemDiscovery), "Scan");
                _logger.LogDebug("FenomHubSystemDiscovery: Scan");

                if (IsScanning)
                {
                    _logger.LogError("FenomHubSystemDeiscovery.Scan() - already scanning");
                    return null;
                }

                //var deviceList = AsyncHelper.RunSync(() =>
                _bleRadio.Scan(scanTime.TotalMilliseconds,
                    ((IBleDevice bleDevice) =>
                    {
                        // TODO: do filter here
                        if ((bleDevice != null) && (!string.IsNullOrEmpty(bleDevice.Name)))
                        {
                            if (bleDevice.Name.StartsWith("LOCK"))
                            {
                                deviceFoundCallback?.Invoke(bleDevice);
                            }
                        }
                    }),
                    ((IEnumerable<IBleDevice> bleDevices) =>
                    {
                        // TODO: do filter here
                        scanCompletedCallback?.Invoke(bleDevices);
                    }),
                    (() =>
                    {

                    })
                );
                //);

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return null;
            }
            finally
            {
                PerformanceLogger.EndLog(typeof(FenomHubSystemDiscovery), "Scan");
            }
        }

        /// <summary>
        /// StopScan
        /// </summary>
        public void StopScan()
        {
            PerformanceLogger.StartLog(typeof(FenomHubSystemDiscovery), "StopScan");
            _logger.LogDebug("FenomHubSystemDiscovery: StopScan");

            AsyncHelper.RunSync(() => _bleRadio.StopScan());

            PerformanceLogger.EndLog(typeof(FenomHubSystemDiscovery), "StopScan");
        }
    }
}