using System;
using System.Collections.Generic;

namespace FenomPlus.Database.Tables
{
    public class BreathManeuverTb : BaseTb<BreathManeuverTb>
    {
        public DateTime DateOfTest { get; set; }
        public short TestNumber { get; set; }
        public byte Temperature { get; set; }
        public byte Pressure { get; set; }
        public byte BreathFlow { get; set; }
        public short NOScore { get; set; }
        public byte StatusCode { get; set; }
    }
}