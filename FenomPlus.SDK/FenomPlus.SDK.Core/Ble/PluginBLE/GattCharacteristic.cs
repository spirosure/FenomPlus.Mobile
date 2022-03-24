using Plugin.BLE.Abstractions;
using Polly;
using FenomPlus.SDK.Core.Ble.Interface;
using FenomPlus.SDK.Core.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FenomPlus.SDK.Core.Ble.PluginBLE
{
    public class GattCharacteristic : IGattCharacteristic
    {
        private enum MonitorType
        {
            None,
            Characteristic
        };

        private readonly ConcurrentDictionary<int, IEnumerable<Action<byte[]>>> _notificationDict;
        private Action<byte[]> _notificationCallback;
        private MonitorType _monitorType = MonitorType.None;

        private SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characteristic"></param>
        public GattCharacteristic(Plugin.BLE.Abstractions.Contracts.ICharacteristic characteristic)
        {
            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "GattCharacteristic");
                Characteristic = characteristic;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "GattCharacteristic");
            }
        }

        private Plugin.BLE.Abstractions.Contracts.ICharacteristic Characteristic { get; }
        public Guid Uuid => Characteristic.Id;
        public string Description => Characteristic.Name;
        public bool IsNotifying => _monitorType != MonitorType.None;
        public CharacteristicPropertiesEnum Properties => throw new NotImplementedException();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task EnableMonitorAsync(Action<byte[]> callback)
        {
            await _lock.WaitAsync();

            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "EnableMonitorAsync");
                _monitorType = MonitorType.Characteristic;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "EnableMonitorAsync");
                _lock.Release();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task DisableMonitorAsync()
        {
            await _lock.WaitAsync();

            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "DisableMonitorAsync");

                
                await Characteristic.StopUpdatesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "DisableMonitorAsync");
                _lock.Release();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configId"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task EnableWatcher(int configId, Action<byte[]> callback)
        {
            await _lock.WaitAsync();

            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "EnableWatcher");

                if (!_notificationDict.ContainsKey(configId))
                {
                    _notificationDict[configId] = new List<Action<byte[]>>();
                }

                (_notificationDict[configId] as List<Action<byte[]>>).Add(callback);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "EnableWatcher");
                _lock.Release();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configId"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task DisableWatcher(int configId, Action<byte[]> callback)
        {
            await _lock.WaitAsync();

            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "DisableWatcher");

                

                Console.WriteLine("GattCharacteristic.DisableWatcher() - Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "DisableWatcher");
                _lock.Release();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> ReadAsync()
        {
            //await _lock.WaitAsync();

            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "ReadAsync");

                if (!Characteristic.CanRead)
                {
                    throw new Exception("Characteristic cannot be read");
                }
                var policy = Policy
                    .Handle<Plugin.BLE.Abstractions.Exceptions.CharacteristicReadException>()
                    .WaitAndRetry(3, retryAttempt => TimeSpan.FromMilliseconds(100),
                        (exception, timeSpan, retryCount, context) =>
                        {
                            // log failed read in here
                        });

                return await policy.Execute(async () => await Characteristic.ReadAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                //_lock.Release();
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "ReadAsync");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> WriteAsync(byte[] value)
        {
            await _lock.WaitAsync();

            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "WriteAsync");

                if (!Characteristic.CanWrite)
                {
                    throw new Exception("Characteristic cannot be written");
                }

                Characteristic.WriteType = CharacteristicWriteType.WithResponse;

                var policy = Policy
                    .Handle<Exception>()
                    .WaitAndRetry(3, retryAttempt => TimeSpan.FromMilliseconds(100),
                        (exception, timeSpan, retryCount, context) =>
                        {
                            // log failed write in here
                        });

                return await policy.Execute(() => Characteristic.WriteAsync(value));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _lock.Release();
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "WriteAsync");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task WriteWithoutResponseAsync(byte[] value)
        {
            await _lock.WaitAsync();

            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "WriteWithoutResponseAsync");

                if (!Characteristic.CanWrite)
                {
                    throw new Exception("Characteristic cannot be written");
                }

                Characteristic.WriteType = CharacteristicWriteType.WithoutResponse;

                var policy = Policy
                    .Handle<Exception>()
                    .WaitAndRetry(3, retryAttempt => TimeSpan.FromMilliseconds(100),
                        (exception, timeSpan, retryCount, context) =>
                        {
                            // log failed write in here
                        });

                await policy.Execute(() => Characteristic.WriteAsync(value));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _lock.Release();
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "WriteWithoutResponseAsync");
            }
        }

        
    }
}
