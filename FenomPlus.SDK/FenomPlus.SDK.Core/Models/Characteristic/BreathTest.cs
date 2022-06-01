using System;
using System.Runtime.InteropServices;

namespace FenomPlus.SDK.Core.Models.Characteristic
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class BreathTest : BaseCharacteristic
    {
        public byte TestNumber;
    }
}
