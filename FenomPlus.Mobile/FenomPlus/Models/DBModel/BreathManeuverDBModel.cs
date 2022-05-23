using System;
using FenomPlus.Database.Tables;
using FenomPlus.SDK.Core.Models.Characteristic;

namespace FenomPlus.Models
{
    public class BreathManeuverDBModel : BreathManeuverTb
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static BreathManeuverDBModel Create(BreathManeuver input)
        {
            return new BreathManeuverDBModel()
            {
                Id = null,
                BreathFlow = input.BreathFlow,
                DateOfTest = DateTime.Now,
                NOScore = input.NOScore,
                Pressure = input.Pressure,
                StatusCode = input.StatusCode,
                Temperature = input.Temperature,
                TestNumber = input.TestNumber
            };
        }
    }
}
