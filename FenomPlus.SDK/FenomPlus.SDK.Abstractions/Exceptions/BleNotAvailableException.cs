using System;
using System.Runtime.Serialization;

namespace FenomPlus.SDK.Abstractions.Exceptions
{
    public class BleNotAvailableException : Exception
    {
        public BleNotAvailableException()
        {
        }

        public BleNotAvailableException(string message) : base(message)
        {
        }

        public BleNotAvailableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BleNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
