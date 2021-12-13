using System;
using System.Threading;

namespace FenomPlus.SDK.Core.Ble
{
    public static class BleLocker
    {
        public static SemaphoreSlim Lock { get; } = new SemaphoreSlim(1, 1);
    }
}
