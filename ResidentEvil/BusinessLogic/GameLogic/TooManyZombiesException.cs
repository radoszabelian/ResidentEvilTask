using System;
using System.Runtime.Serialization;

namespace ResidentEvil.BusinessLogic.GameLogic
{
    [Serializable]
    internal class TooManyZombiesException : Exception
    {
        public TooManyZombiesException()
        {
        }

        public TooManyZombiesException(string message) : base(message)
        {
        }

        public TooManyZombiesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TooManyZombiesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}