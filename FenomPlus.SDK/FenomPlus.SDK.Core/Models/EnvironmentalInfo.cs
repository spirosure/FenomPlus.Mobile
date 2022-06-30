using System;
using System.Runtime.InteropServices;

namespace FenomPlus.SDK.Core.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class EnvironmentalInfo : BaseCharacteristic
    {
        public static int Min = 4;

        public byte Temperature;
        public byte Humidity;
        public byte Pressure;
        public byte BatteryLevel;       // new version

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static EnvironmentalInfo Create(byte[] data)
        {
            EnvironmentalInfo environmentalInfo = new EnvironmentalInfo();
            return environmentalInfo.Decode(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public EnvironmentalInfo Decode(byte[] data)
        {
            try
            {
                Data = data;
                if ((data != null) && (data.Length >= Min))
                {
                    Temperature = Data[0];
                    Humidity = Data[1];
                    Pressure = Data[2];
                    BatteryLevel = Data[3];
                }
            } finally { }
            return this;
        }

    }
}
