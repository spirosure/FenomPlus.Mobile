using System;

namespace FenomPlus.SDK.Core.Models.Characteristic
{
    public class BaseCharacteristic
    {
        protected bool NewVersion = App.DeviceNewVersion;

        // store orginal data
        protected byte[] Data;

    }
}
