using System;
using FenomPlus.SDK.Core.Models.Characteristic;

namespace FenomPlus.Models
{
    public class BreathManeuverModel
    {
        public string Id { get; set; }
        public DateTime DateOfTest { get; set; }
        public short TestNumber { get; set; }
        public byte Temperature { get; set; }
        public byte Pressure { get; set; }
        public byte BreathFlow { get; set; }
        public short NOScore { get; set; }
        public byte StatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static BreathManeuverModel Create(BreathManeuver input)
        {
            return new BreathManeuverModel()
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
