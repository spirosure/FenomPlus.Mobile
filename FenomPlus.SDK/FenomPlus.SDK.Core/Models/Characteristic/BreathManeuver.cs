using System;
using System.Runtime.InteropServices;

namespace FenomPlus.SDK.Core.Models.Characteristic
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class BreathManeuver
    {
        public short TestNumber;
        public byte TimeRemaining;
        public byte Temperature;
        public byte Pressure;
        public byte BreathFlow;
        public short NOScore;
        public byte AnalysisTimeLeft;
        public byte StatusCode;
    }
}
