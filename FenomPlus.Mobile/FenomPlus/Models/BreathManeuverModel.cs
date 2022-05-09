using System;

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
    }
}
