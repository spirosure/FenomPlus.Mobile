
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
        public static BreathManeuverModel Convert(this BreathManeuverTb input)
        {
            if (input == null) return null;
            return new BreathManeuverModel()
            {
                Id = input.Id,
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
        public static BreathManeuverTb Convert(this BreathManeuverModel input)
        {
            if (input == null) return null;
            return new BreathManeuverTb()
            {
                Id = input.Id,
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
