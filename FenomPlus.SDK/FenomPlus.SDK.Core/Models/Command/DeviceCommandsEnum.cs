using System;
namespace FenomPlus.SDK.Core.Models.Command
{
    public enum DeviceCommandsEnum
    {
        DeviceInfo = 0x80,
        FirmwareUpgrade = 0x81,
        FirmwareData = 0x82,
        GetEnvironmentalValues = 0x83,
        PerformBreathTest = 0x84,
        BreathManeuver = 0x85,
        TestLog = 0x86,
        PerformOppbTest = 0x87,
        GetQCUserData = 0x88,
        UpdateQCUserData = 0x89,
        UserTraining = 0x8A
    }
}
