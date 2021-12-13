using System;

namespace FenomPlus.SDK.Core.Ble.Interface
{
    public enum CharacteristicPropertiesEnum
    {
        Broadcast = 1,
        Read = 2,
        WriteNoResposne = 4,
        Write = 8,
        Notify = 16,
        Indicate = 32,
        AuthenticatedSigneWrites = 64,
        ExtendedPropties = 128,
        NotifyEncryptedRequired = 256,
        IndicateEncryptionRequired = 512
    }
}
