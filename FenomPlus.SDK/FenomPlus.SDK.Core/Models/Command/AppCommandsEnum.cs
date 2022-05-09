using System;
namespace FenomPlus.SDK.Core.Models.Command
{
    public enum AppCommandsEnum
    {
        DeviceInfo = 0x00,
        FirmwareUpgrade = 0x00,
        FirmwareData = 0x00,
        GetEnvironmentalValues = 0x00,
        PerformBreathTest = 0x00,
        BreathManeuver = 0x00,
        TestLog = 0x00,
        PerformOppbTest = 0x00,
        GetQCUserData = 0x00,
        UpdateQCUserData = 0x00,
        UserTraining = 0x00,
    }
}
