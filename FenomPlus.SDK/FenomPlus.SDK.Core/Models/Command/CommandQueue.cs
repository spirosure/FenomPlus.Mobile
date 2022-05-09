using System;
using System.Collections.Generic;
using FenomPlus.SDK.Core.Ble.Interface;

namespace FenomPlus.SDK.Core.Models.Command
{
    public class CommandQueue
    {
        private Dictionary<Guid, CommandMessage> _messages;
        private object lock_Object = new object();

        /// <summary>
        /// 
        /// </summary>
        public CommandQueue()
        {
            _messages = new Dictionary<Guid, CommandMessage>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="callBack"></param>
        /// <returns></returns>
        public Guid Subscribe(IBleDevice subscriber, Action<IBleDevice, byte[], CommandPacket> callBack = null)
        {
            Guid token = Guid.NewGuid();
            lock (lock_Object)
            {
                _messages.Add(token, CommandMessage.Create(subscriber, token, callBack));
            }
            return token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        public void UnSubscribe(Guid token)
        {
            lock (lock_Object)
            {
                if ((_messages.Count > 0) && _messages.ContainsKey(token))
                {
                    _messages.Remove(token);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="command"></param>
        /// <param name="data"></param>
        public void Publish(IBleDevice sender, byte[] data, CommandPacket command)
        {
            lock (lock_Object)
            {
                if (_messages.Count > 0)
                {
                    foreach (KeyValuePair<Guid, CommandMessage> item in _messages)
                    {
                        try
                        {
                            item.Value?.ExecuteCallBack(sender, data, command);
                        }
                        catch (Exception ex)
                        {
                            // if any exception then UnSubscribe
                            UnSubscribe(item.Key);
                        }
                    }
                }
            }
        }
    }
}
