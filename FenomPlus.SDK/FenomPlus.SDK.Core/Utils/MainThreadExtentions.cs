using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FenomPlus.SDK.Core.Utils
{
    public static partial class MainThreadEX
    {
        public static async Task<bool> EnsureMainThread()
        {
            if (!MainThread.IsMainThread && (DeviceInfo.Platform == DevicePlatform.Android))
            {
                await MainThread.InvokeOnMainThreadAsync(async () => await EnsureMainThread());
                return true;
            }
            return false;
        }
    }
}
