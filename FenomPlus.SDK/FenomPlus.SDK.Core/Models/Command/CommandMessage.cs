using System;
using FenomPlus.SDK.Core.Ble.Interface;

namespace FenomPlus.SDK.Core.Models.Command
{
    public class CommandMessage
    {
        public Guid Token;
        public IBleDevice Subscriber;
        public IBleDevice Sender;
        public byte[] Data;
        public Action<IBleDevice, byte[], CommandPacket> CallBack;
        public CommandPacket Command;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="token"></param>
        /// <param name="callBack"></param>
        public CommandMessage(IBleDevice subscriber, Guid token, Action<IBleDevice, byte[], CommandPacket> callBack)
        {
            Subscriber = subscriber;
            Token = token;
            CallBack = callBack;
            Sender = subscriber;
            Subscriber = null;
            Data = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="token"></param>
        /// <param name="callBack"></param>
        /// <returns></returns>
        public static CommandMessage Create(IBleDevice subscriber, Guid token, Action<IBleDevice, byte[], CommandPacket> callBack = null)
        {
            return new CommandMessage(subscriber, token, callBack);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        /// <param name="command"></param>
        public void ExecuteCallBack(IBleDevice sender, byte[] data, CommandPacket command)
        {
            if (CallBack != null)
            {
                this.Sender = sender;
                this.Data = data;
                this.Command = command;
                CallBack?.Invoke(sender, data, command);
            }
        }
    }
}
