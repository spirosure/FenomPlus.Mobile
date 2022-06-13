using System;
using System.Runtime.InteropServices;

namespace FenomPlus.SDK.Core.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class TrainingMode : BaseCharacteristic
    {
        public byte Mode;
    }
}
