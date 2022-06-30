using System;
using System.Runtime.InteropServices;

namespace FenomPlus.SDK.Core.Models
{
    // 8 bytes old * 9 bytes new
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class BreathManeuver : BaseCharacteristic
    {
        public static int Min = 13;

        public short TestNumber;
        public byte  TimeRemaining;
        public byte  Temperature;
        public byte  Pressure;
        public byte  BreathFlow;
        public short NOScore;
        public byte  AnalysisTimeLeft;
        public byte  StatusCode;
        public byte  BreathGaugePressure;
        public short NOCounts;
        public byte  SampleMassFlow;

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
            try
            {
                Data = data;
                if ((data != null) && (data.Length >= Min))
                {
                    TestNumber = (short)((int)(((int)Data[0]) * 256 + (int)Data[1]));
                    TimeRemaining = Data[2];
                    Temperature = Data[3];
                    Pressure = Data[4];
                    BreathFlow = Data[5];
                    NOScore = (short)((int)(((int)Data[6]) * 256 + (int)Data[7]));
                    AnalysisTimeLeft = Data[8];
                    StatusCode = Data[9];
                    BreathGaugePressure = Data[10];
                    NOCounts = (short)((int)(((int)Data[11]) * 256 + (int)Data[12]));
                    SampleMassFlow = Data[13];
                }
            } finally { }
            return this;
        }

    }
}
