using System;

namespace FenomPlus.SDK.Core.Models
{
    public class BasePacket
    {
        public byte[] Data { get; set; }
        public bool IsValid { get { return (Data != null) && (Data.Length > 0); } }

        public byte Extract8(byte[] data, int index)
        {
            return (data[index]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int Extract16(byte[] data, int index)
        {
            return (data[index + 0] << 8) |
                    (data[index + 1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int Extract32(byte[] data, int index)
        {
            return (data[index + 0] << 24) |
                    (data[index + 1] << 16) |
                    (data[index + 2] << 8) |
                    (data[index + 3]);
        }
    }
}
