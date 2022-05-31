using System;
using FenomPlus.Database.Tables;
using FenomPlus.Models;

namespace FenomPlus.Database.Adapters
{
    public static class QualityControlDevicesAdapter
    {
        public static QualityControlDeviceDBModel Convert(this QualityControlDevicesTb input)
        {
            if (input == null) return null;
            return new QualityControlDeviceDBModel()
            {
                _id = input._id,
                //Id = input.Id != null ? input.Id : Guid.NewGuid().ToString(),
                LastConnected = input.LastConnected,
                SerialNumber = input.SerialNumber
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static QualityControlDevicesTb Convert(this QualityControlDeviceDBModel input)
        {
            if (input == null) return null;
            return new QualityControlDevicesTb()
            {
                _id = input._id,
                //Id = input.Id != null ? input.Id : Guid.NewGuid().ToString(),
                LastConnected = input.LastConnected,
                SerialNumber = input.SerialNumber
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static QualityControlDevicesDataModel ConvertForGrid(this QualityControlDevicesTb input)
        {
            if (input == null) return null;
            return new QualityControlDevicesDataModel()
            {
                _id = input._id,
                //Id = input.Id != null ? input.Id : Guid.NewGuid().ToString(),
                LastConnected = input.LastConnected,
                SerialNumber = input.SerialNumber
            };
        }
    }
}
