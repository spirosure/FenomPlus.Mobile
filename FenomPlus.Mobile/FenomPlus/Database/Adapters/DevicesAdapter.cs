using System;
using FenomPlus.Database.Tables;
using FenomPlus.Models;

namespace FenomPlus.Database.Adapters
{
    public static class DevicesAdapter
    {
        public static DeviceModel Convert(this DevicesTb input)
        {
            if (input == null) return null;
            return new DeviceModel()
            {
                Id = input.Id
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DevicesTb Convert(this DeviceModel input)
        {
            if (input == null) return null;
            return new DevicesTb()
            {
                Id = input.Id
            };
        }
    }
}
