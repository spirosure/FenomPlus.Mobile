using System;
using System.Collections.Generic;

namespace FenomPlus.Database.Tables
{
    public class BreathManeuverResultTb : BaseTb<BreathManeuverResultTb>
    {
        // from sensor all info here
        public short TestNumber { get; set; }
        public byte Temperature { get; set; }
        public byte Pressure { get; set; }
        public byte BreathFlow { get; set; }
        public short NOScore { get; set; }
        public byte StatusCode { get; set; }

        // for grid display
        public string SerialNumber { get; set; }
        public string TestType { get; set; }
        public DateTime DateOfTest { get; set; }
        public string QCStatus { get; set; }
        public string TestResult { get; set; }

    }
}