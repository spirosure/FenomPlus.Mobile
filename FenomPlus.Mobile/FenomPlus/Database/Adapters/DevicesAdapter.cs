using System;
using FenomPlus.Database.Tables;
using FenomPlus.Models;

namespace FenomPlus.Database.Adapters
{
    public static class DevicesAdapter
    {
        public static DeviceDBModel Convert(this DevicesTb input)
        {
            if (input == null) return null;
            return new DeviceDBModel()
            {
                Id = input.Id
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DevicesTb Convert(this DeviceDBModel input)
        {
            if (input == null) return null;
            return new DevicesTb()
            {
                Id = input.Id
            };
        }
    }
}
