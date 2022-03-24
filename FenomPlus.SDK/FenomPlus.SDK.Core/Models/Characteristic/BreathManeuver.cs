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

        // store orginal data
        public byte[] Data;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static BreathManeuver Create(byte[] data)
        {
            BreathManeuver breathManeuver = new BreathManeuver();
            return breathManeuver.Decode(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BreathManeuver Decode(byte[] data)
        {
            Data = data;
            if((data != null) && (data.Length == 10))
            {
                TestNumber          = (short)((int)(((int)Data[0])*256 + (int)Data[1]));
                TimeRemaining       = Data[2];
                Temperature         = Data[3];
                Pressure            = Data[4];
                BreathFlow          = Data[5];
                NOScore             = (short)((int)(((int)Data[6])*256 + (int)Data[7]));
                AnalysisTimeLeft    = Data[8];
                StatusCode          = Data[9];
            }
            return this;
        }
    }
}
