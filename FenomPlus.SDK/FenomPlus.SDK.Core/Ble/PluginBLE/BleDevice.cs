using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using FenomPlus.SDK.Core.Ble.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FenomPlus.SDK.Core.Utils;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Exceptions;
using FenomPlus.SDK.Core.Models.Command;
using FenomPlus.SDK.Core.Models.Characteristic;

namespace FenomPlus.SDK.Core.Ble.PluginBLE
{
    internal class BleDevice : IBleDevice
    {
        // need Adapter
        private static readonly IBluetoothLE Ble = CrossBluetoothLE.Current;
        private static readonly IAdapter Adapter = Ble.Adapter;
        private Logger _logger = new Logger(nameof(BleDevice));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public BleDevice(IDevice device)
        {
            PerformanceLogger.StartLog(typeof(BleDevice), "BleDevice");
            Device = device;
            PerformanceLogger.EndLog(typeof(BleDevice), "BleDevice");
        }

        // get device here injected from constuctor
        private IDevice Device { get; set; }
        public object NativeDevice => Device.NativeDevice;

        public string Name => Device?.Name;
        public int? Rssi => Device?.Rssi;
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string HardwareVersion { get; set; }
        public string FirmwareVersion { get; set; }
        public string SoftwareVersion { get; set; }
        public string SerialNumber { get; set; }
        public string PairSerialNumber { get; set; }
        public bool IsBonded { get; set; }

        public bool Connected => Device.State == DeviceState.Connected;

        public IEnumerable<IGattCharacteristic> GattCharacteristics { get; } = new SynchronizedList<IGattCharacteristic>();
        public IEnumerable<IService> GattServices { get; } = new SynchronizedList<IService>();

        public Guid Uuid => Device.Id;

        /// <summary>
        /// Connects to this Device
        /// </summary>
        /// <returns>bool for success or failure</returns>
        public async Task<bool> ConnectAsync()
        {
            try
            {
                PerformanceLogger.StartLog(typeof(BleDevice), "ConnectAsync");

                if (!(GattCharacteristics is SynchronizedList<IGattCharacteristic> gattCharacteristics))
                {
                    _logger.LogError("BleDevice.ConnectAsync() - did not find gatt characteristics");
                    return false;
                }

                if (Device.State == DeviceState.Disconnected)
                {
                    var device = await Adapter.ConnectToKnownDeviceAsync(Device.Id, new ConnectParameters(true, true));

                    if (device is null)
                    {
                        _logger.LogError("BleDevice.ConnectAsync() - ConnectToKnownDeviceAsync failed.");
                        return false;
                    }

                    if (device.State == DeviceState.Connected)
                    {
                        Device = device;

                        _ = await GetCharacterasticsAync();

                        return true;
                    }
                }
                else if (Device.State == DeviceState.Limited)
                {
                    await Adapter.ConnectToDeviceAsync(Device, new ConnectParameters(true, true));
                }

                return Device.State == DeviceState.Connected;
            }
            catch (DeviceConnectionException ex)
            {
                Console.WriteLine("BleDevice.DeviceConnectionException(): " + ex.Message);
                _logger.LogException(ex);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("BleDevice.ConnectAsync(): " + ex.Message);
                _logger.LogException(ex);
                return false;
            }
            finally
            {
                PerformanceLogger.EndLog(typeof(BleDevice), "ConnectAsync");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task DisconnectAsync()
        {
            try
            {
                PerformanceLogger.StartLog(typeof(BleDevice), "DisconnectAsync");

                var gattCharacteristics = GattCharacteristics as SynchronizedList<IGattCharacteristic>;
                gattCharacteristics?.Clear();

                if (!Connected)
                {
                    return;
                }

                await Adapter.DisconnectDeviceAsync(Device);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally
            {
                PerformanceLogger.EndLog(typeof(BleDevice), "DisconnectAsync");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IGattCharacteristic>> GetCharacterasticsAync()
        {
            try
            {
                PerformanceLogger.StartLog(typeof(BleDevice), "GetCharacterasticsAync");

                var gattCharacteristics = GattCharacteristics as SynchronizedList<IGattCharacteristic>;

                if (gattCharacteristics == null)
                {
                    _logger.LogWarning("BleDevice.GetCharacteristicsAsync() - list is null");
                    return null;
                }

                gattCharacteristics.Clear();

                
                var gattService = GattServices as SynchronizedList<IService>;

                var services = await Device.GetServicesAsync();

                foreach (var service in services)
                {
                    // add service here
                    gattService.Add(service);

                    var characteristics = await service.GetCharacteristicsAsync();

                    foreach (var characteristic in characteristics)
                    {
                        gattCharacteristics.Add(new GattCharacteristic(characteristic));
                    }
                }

                return gattCharacteristics;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return null;
            }
            finally
            {
                PerformanceLogger.EndLog(typeof(BleDevice), "GetCharacterasticsAync");
            }
        }

        public Task<bool> EnsureConnected()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatedRssi()
        {
            throw new NotImplementedException();
        }

        public Task<IGattCharacteristic> GetCharacterasticsAync(Guid gattCharacteristicUuid)
        {
            throw new NotImplementedException();
        }

        public Task<IGattCharacteristic> GetCharacterasticsAync(string gattCharacteristicUuid)
        {
            throw new NotImplementedException();
        }

        public Guid Subscribe(IBleDevice subscriber, Action<IBleDevice, byte[], CommandPacket> callBack = null)
        {
            throw new NotImplementedException();
        }

        public void UnSubscribe(Guid token)
        {
            throw new NotImplementedException();
        }

        private byte breathFlow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public async Task<IGattCharacteristic> FindCharacteristic(string uuid)
        {
            Guid guid = new Guid(uuid);
            IGattCharacteristic gatt = null;

            // have we read it yet ?
            //var gattService = GattServices as SynchronizedList<IService>;
            //IService service = gattService[gattService.Count - 1];
            //gatt = await service.GetCharacteristicAsync(guid);

            var gattCharacteristics = GattCharacteristics as SynchronizedList<IGattCharacteristic>;
            if(gattCharacteristics.Count <= 0)
            {
                _ = GetCharacterasticsAync();
                gattCharacteristics = GattCharacteristics as SynchronizedList<IGattCharacteristic>;
            }
            foreach (IGattCharacteristic item in gattCharacteristics)
            {
                if (!item.Uuid.Equals(guid)) continue;
                gatt = item;
                break;
            }

            return gatt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> StartMesurementFeature(BreathTestEnum breathTestEnum = BreathTestEnum.Start10Second)
        {
            breathFlow = 0;
            IGattCharacteristic Characteristic = await FindCharacteristic(Constants.BreathTestCharacteristic);
            byte[] data = new byte[1];
            data[0] = (byte)breathTestEnum;
            await Characteristic.WriteAsync(data);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> StopMesurementFeature()
        {
            IGattCharacteristic Characteristic = await FindCharacteristic(Constants.BreathTestCharacteristic);
            byte[] data = new byte[1];
            data[0] = (byte)BreathTestEnum.Stop;
            await Characteristic.WriteAsync(data);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<float> ReadMesurementFeature()
        {
            return 25.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<BreathManeuver> ReadBreathManeuverFeature()
        {
            BreathManeuver breathManeuver = null;
            IGattCharacteristic Characteristic = await FindCharacteristic(Constants.BreathManeuverCharacteristic);
            var data = await Characteristic.ReadAsync();
            if ((data != null) && (data.Length >= 10)) {
                breathManeuver = BreathManeuver.Create(data);
            }
            return breathManeuver;
        }

    }
}
