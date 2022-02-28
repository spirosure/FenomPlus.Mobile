using System;
using System.Runtime.InteropServices;

namespace FenomPlus.SDK.Core.Models.Characteristic
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class EnvironmentalInfo
    {
        public byte Temperature;
        public byte Humidity;
        public byte Pressure;
    }
}
