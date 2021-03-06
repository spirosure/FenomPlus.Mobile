using FenomPlus.Database.Tables;
using FenomPlus.Enums;
using FenomPlus.SDK.Core.Models;
using FenomPlus.Services;
using System;

namespace FenomPlus.Models
{
    public class BreathManeuverErrorDBModel : BreathManeuverErrorTb
    {

        public BreathManeuverErrorDBModel() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static BreathManeuverErrorDBModel Create(BreathManeuver input)
        {
            int statusCode = (input.StatusCode >= ErrorCodesEnum.codes.Length) ? ErrorCodesEnum.codes.Length : input.StatusCode;

            return new BreathManeuverErrorDBModel()
            {
                Description = ErrorCodesEnum.codes[statusCode],
                SerialNumber = IOC.Services.Cache.DeviceSerialNumber,
                Software = IOC.Services.Cache.Firmware,
                Firmware = IOC.Services.Cache.Firmware,
                DateError = DateTime.Now.ToString(),
                Humidity = IOC.Services.Cache._EnvironmentalInfo.Humidity.ToString()
            };
        }
    }
}
 