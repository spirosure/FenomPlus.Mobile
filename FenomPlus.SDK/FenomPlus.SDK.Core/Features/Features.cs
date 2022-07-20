using System;
using System.Threading.Tasks;
using FenomPlus.SDK.Core.Ble.Interface;
using FenomPlus.SDK.Core.Features;
using FenomPlus.SDK.Core.Models;

namespace FenomPlus.SDK.Core.Ble.PluginBLE
{
    internal partial class BleDevice
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DEVICEINFO()
        {
            MESSAGE message = new MESSAGE()
            {
                IDMSG = (ushort)ID_MESSAGE.ID_REQUEST_DATA,
                IDSUB = (ushort)ID_SUB.ID_DEVICEINFO,
                IDVAR = 0
            };
            return await WRITEREQUEST(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ENVIROMENTALINFO()
        {
            MESSAGE message = new MESSAGE()
            {
                IDMSG = (ushort)ID_MESSAGE.ID_REQUEST_DATA,
                IDSUB = (ushort)ID_SUB.ID_ENVIROMENTALINFO,
                IDVAR = 0
            };
            return await WRITEREQUEST(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> BREATHTEST(BreathTestEnum breathTestEnum = BreathTestEnum.Start10Second)
        {
            MESSAGE message = new MESSAGE()
            {
                IDMSG = (ushort)ID_MESSAGE.ID_REQUEST_DATA,
                IDSUB = (ushort)ID_SUB.ID_BREATHTEST,
                IDVAR = (UInt64)breathTestEnum
            };
            return await WRITEREQUEST(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> BREATHMANUEVER()
        {
            MESSAGE message = new MESSAGE()
            {
                IDMSG = (ushort)ID_MESSAGE.ID_REQUEST_DATA,
                IDSUB = (ushort)ID_SUB.ID_BREATHMANUEVER,
                IDVAR = 0
            };
            return await WRITEREQUEST(message);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> TRAININGMODE()
        {
            MESSAGE message = new MESSAGE()
            {
                IDMSG = (ushort)ID_MESSAGE.ID_REQUEST_DATA,
                IDSUB = (ushort)ID_SUB.ID_TRAININGMODE,
                IDVAR = 0
            };
            return await WRITEREQUEST(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DEBUGMSG()
        {
            MESSAGE message = new MESSAGE()
            {
                IDMSG = (ushort)ID_MESSAGE.ID_REQUEST_DATA,
                IDSUB = (ushort)ID_SUB.ID_DEBUGMSG,
                IDVAR = 0
            };
            return await WRITEREQUEST(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DEBUGMANUEVERTYPE()
        {
            MESSAGE message = new MESSAGE()
            {
                IDMSG = (ushort)ID_MESSAGE.ID_REQUEST_DATA,
                IDSUB = (ushort)ID_SUB.ID_DEBUGMANUEVERTYPE,
                IDVAR = 0
            };
            return await WRITEREQUEST(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<bool> MESSAGE(MESSAGE message)
        {
            return await WRITEREQUEST(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task<bool> WRITEREQUEST(MESSAGE message)
        {
            byte[] data = new byte[2+2+8];
            data[0] = (byte)(message.IDMSG >> 8);
            data[1] = (byte)(message.IDMSG);
            data[2] = (byte)(message.IDSUB >> 8);
            data[3] = (byte)(message.IDSUB);
            data[4] = (byte)(message.IDVAR >> 56);
            data[4] = (byte)(message.IDVAR >> 48);
            data[4] = (byte)(message.IDVAR >> 40);
            data[4] = (byte)(message.IDVAR >> 32);
            data[4] = (byte)(message.IDVAR >> 24);
            data[4] = (byte)(message.IDVAR >> 16);
            data[4] = (byte)(message.IDVAR >> 8);
            data[5] = (byte)(message.IDVAR);
            IGattCharacteristic Characteristic = await FindCharacteristic(Constants.FeatureWriteCharacteristic);
            if (Characteristic != null)
            {
                await Characteristic.WriteWithoutResponseAsync(data);
                return true;
            }
            return false;
        }
    }
}
