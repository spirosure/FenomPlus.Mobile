using System;
using System.Linq;
using System.Threading.Tasks;
using FenomPlus.SDK.Core.Ble.Interface;

namespace FenomPlus.SDK.Core.Features
{
    public class BaseFeature
    {
        public static Guid SERVICE_GUID = new Guid("3e520001-1368-b682-4440-d7dd234c45bc");
        public static Guid TX_CHAR_GUID = new Guid("3e520002-1368-b682-4440-d7dd234c45bc");
        public static Guid RX_CHAR_GUID = new Guid("3e520003-1368-b682-4440-d7dd234c45bc");

        /// <summary>
        /// Cheat for now
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static byte[] GetBytes(string text)
        {
            return text.Split(' ').Where(token => !string.IsNullOrEmpty(token)).Select(token => Convert.ToByte(token, 16)).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bleDevice"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<bool> SafeWriteAsync(IBleDevice bleDevice, byte[] data)
        {
            IGattCharacteristic gattCharacteristic = await bleDevice.GetCharacterasticsAync(TX_CHAR_GUID);
            if (gattCharacteristic == null) return false;
            await gattCharacteristic.WriteWithoutResponseAsync(data);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bleDevice"></param>
        /// <returns></returns>
        public static async Task<bool> EnsureConnected(IBleDevice bleDevice)
        {
            if (bleDevice == null) return false;
            return await bleDevice.EnsureConnected();
        }
    }
}
