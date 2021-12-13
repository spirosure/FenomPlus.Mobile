using System;
using System.Runtime.Serialization;

namespace FenomPlus.SDK.Abstractions.Exceptions
{
    public class MissingBondedDeviceException : Exception
    {
        public MissingBondedDeviceException()
        {
        }

        public MissingBondedDeviceException(string message) : base(message)
        {
        }

        public MissingBondedDeviceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingBondedDeviceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}