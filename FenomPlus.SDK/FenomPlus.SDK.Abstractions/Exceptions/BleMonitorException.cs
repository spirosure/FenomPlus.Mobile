using System;
using System.Runtime.Serialization;

namespace FenomPlus.SDK.Abstractions.Exceptions
{
    public class BleMonitorException : Exception
    {
        public BleMonitorException()
        {
        }

        public BleMonitorException(string message) : base(message)
        {
        }

        public BleMonitorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BleMonitorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
