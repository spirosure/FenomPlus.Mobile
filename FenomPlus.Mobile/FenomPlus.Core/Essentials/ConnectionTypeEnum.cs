using System;

namespace FenomPlus.Core.Essentials
{
    public enum ConnectionTypeEnum
    {
        //
        // Summary:
        //     Cellular connection, 3G, Edge, 4G, LTE
        Cellular = 0,
        //
        // Summary:
        //     Wifi connection
        WiFi = 1,
        //
        // Summary:
        //     Desktop or ethernet connection
        Desktop = 2,
        //
        // Summary:
        //     Wimax (only android)
        Wimax = 3,
        //
        // Summary:
        //     Other type of connection
        Other = 4,
        //
        // Summary:
        //     Bluetooth connection
        Bluetooth = 5
    }
}
