using System;
using FenomPlus.Database.Tables;
using FenomPlus.SDK.Core.Models;

namespace FenomPlus.Models
{
    public class BreathManeuverResultDBModel : BreathManeuverResultTb
    {
        public BreathManeuverResultDBModel() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static BreathManeuverResultDBModel Create(BreathManeuver input)
        {
            return new BreathManeuverResultDBModel()
            {
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
