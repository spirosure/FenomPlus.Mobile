﻿using Plugin.BLE.Abstractions;
using FenomPlus.SDK.Core.Ble.Interface;
using FenomPlus.SDK.Core.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;
using Plugin.BLE.Abstractions.EventArgs;
using FenomPlus.Services;
using FenomPlus.Interfaces;

namespace FenomPlus.SDK.Core.Ble.PluginBLE
{
    public class GattCharacteristic : IGattCharacteristic
    {
        private IAppServices Services => IOC.Services;
        private SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        private Plugin.BLE.Abstractions.Contracts.ICharacteristic Characteristic { get; }
        public Guid Uuid => Characteristic.Id;

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
                try
                {
                    PerformanceLogger.StartLog(typeof(GattCharacteristic), "GattCharacteristic");

                    if (Uuid.Equals(Constants.DeviceInfoCharacteristic))
                    {
                        Characteristic.ValueUpdated += DeviceInfoHandler;
                        if (Characteristic.CanUpdate)
                        {
                            Characteristic.StartUpdatesAsync();
                        }
                    }
                    else if (Uuid.Equals(Constants.EnvironmentalInfoCharacteristic))
                    {
                        Characteristic.ValueUpdated += EnvironmentalInfoHandler;
                        if (Characteristic.CanUpdate)
                        {
                            Characteristic.StartUpdatesAsync();
                        }
                    }
                    else if (Uuid.Equals(Constants.BreathManeuverCharacteristic))
                    {
                        Characteristic.ValueUpdated += BreathManeuverHandler;
                        if (Characteristic.CanUpdate)
                        {
                            Characteristic.StartUpdatesAsync();
                        }
                    }
                    else if (Uuid.Equals(Constants.DebugMessageCharacteristic))
                    {
                        Characteristic.ValueUpdated += DebugMsgHandler;
                        if (Characteristic.CanUpdate)
                        {
                            Characteristic.StartUpdatesAsync();
                        }
                    }
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "GattCharacteristic");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> ReadAsync()
        {
            await _lock.WaitAsync();

            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "ReadAsync");

                if (!Characteristic.CanRead)
                {
                    throw new Exception("Characteristic cannot be read");
                }

                return await Characteristic.ReadAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                _lock.Release();
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

            //    Characteristic.WriteType = CharacteristicWriteType.WithResponse;

                return await Characteristic.WriteAsync(value);
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
        public async Task<bool> WriteWithoutResponseAsyncFast(byte[] value)
        {
            await _lock.WaitAsync();
            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "WriteWithoutResponseAsync(" + value.Length + ")");
                Characteristic.WriteType = CharacteristicWriteType.WithoutResponse;
                await Characteristic.WriteAsync(value);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _lock.Release();
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "WriteWithoutResponseAsync");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> WriteWithoutResponseAsync(byte[] value)
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

                await Characteristic.WriteAsync(value);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _lock.Release();
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "WriteWithoutResponseAsync");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceInfoHandler(object sender, CharacteristicUpdatedEventArgs e)
        {
            _lock.Wait();
            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "DeviceInfoHandler");
                IOC.Services.Cache._DeviceInfo.Decode(e.Characteristic.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _lock.Release();
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "DeviceInfoHandler");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnvironmentalInfoHandler(object sender, CharacteristicUpdatedEventArgs e)
        {
            _lock.Wait();
            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "EnvironmentalInfoHandler");
                IOC.Services.Cache._EnvironmentalInfo.Decode(e.Characteristic.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _lock.Release();
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "EnvironmentalInfoHandler");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BreathManeuverHandler(object sender, CharacteristicUpdatedEventArgs e)
        {
            _lock.Wait();
            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "BreathManeuverHandler");
                IOC.Services.Cache._BreathManeuver.Decode(e.Characteristic.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _lock.Release();
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "BreathManeuverHandler");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebugMsgHandler(object sender, CharacteristicUpdatedEventArgs e)
        {
            _lock.Wait();
            try
            {
                PerformanceLogger.StartLog(typeof(GattCharacteristic), "DebugMsgHandler");
                Services.Cache._DebugMsg.Decode(e.Characteristic.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _lock.Release();
                PerformanceLogger.EndLog(typeof(GattCharacteristic), "DebugMsgHandler");
            }
        }
    }
}