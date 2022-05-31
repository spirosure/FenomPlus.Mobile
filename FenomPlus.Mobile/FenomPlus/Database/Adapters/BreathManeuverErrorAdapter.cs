using System;
using FenomPlus.Database.Tables;
using FenomPlus.Models;

namespace FenomPlus.Database.Adapters
{
    public static class BreathManeuverErrorAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static BreathManeuverErrorDBModel Convert(this BreathManeuverErrorTb input)
        {
            if (input == null) return null;
            return new BreathManeuverErrorDBModel()
            {
                _id = input._id,
                //Id = input.Id != null ? input.Id : Guid.NewGuid().ToString(),
                DateError = input.DateError,
                Description = input.Description,
                Firmware = input.Firmware,
                Humidity = input.Humidity,
                SerialNumber = input.SerialNumber,
                Software = input.Software
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static BreathManeuverErrorTb Convert(this BreathManeuverErrorDBModel input)
        {
            if (input == null) return null;
            return new BreathManeuverErrorTb()
            {
                _id = input._id,
                //Id = input.Id != null ? input.Id : Guid.NewGuid().ToString(),
                DateError = input.DateError,
                Description = input.Description,
                Firmware = input.Firmware,
                Humidity = input.Humidity,
                SerialNumber = input.SerialNumber,
                Software = input.Software
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static BreathManeuverErrorDataModel ConvertForGrid(this BreathManeuverErrorTb input)
        {
            if (input == null) return null;
            return new BreathManeuverErrorDataModel()
            {
                _id = input._id,
                //Id = input.Id != null ? input.Id : Guid.NewGuid().ToString(),
                DateError = input.DateError,
                Description = input.Description,
                Firmware = input.Firmware,
                Humidity = input.Humidity,
                SerialNumber = input.SerialNumber,
                Software = input.Software
            };
        }
    }
}
