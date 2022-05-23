
using System;
using FenomPlus.Database.Tables;
using FenomPlus.Models;
using FenomPlus.SDK.Core.Models.Characteristic;

namespace FenomPlus.Database.Adapters
{
    public static class BreathManeuverAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static BreathManeuverDBModel Convert(this BreathManeuverTb input)
        {
            if (input == null) return null;
            return new BreathManeuverDBModel()
            {
                Id = input.Id!= null ? input.Id : Guid.NewGuid().ToString(),
                BreathFlow = input.BreathFlow,
                DateOfTest = input.DateOfTest,
                NOScore = input.NOScore,
                Pressure = input.Pressure,
                StatusCode = input.StatusCode,
                Temperature = input.Temperature,
                TestNumber = input.TestNumber
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static BreathManeuverTb Convert(this BreathManeuverDBModel input)
        {
            if (input == null) return null;
            return new BreathManeuverTb()
            {
                Id = input.Id != null ? input.Id : Guid.NewGuid().ToString(),
                BreathFlow = input.BreathFlow,
                DateOfTest = input.DateOfTest,
                NOScore = input.NOScore,
                Pressure = input.Pressure,
                StatusCode = input.StatusCode,
                Temperature = input.Temperature,
                TestNumber = input.TestNumber
            };
        }
    }
}
