using System;
using System.Runtime.Serialization;

namespace NetDimension.Formium
{
    [Serializable]
    internal class WebBrowserException : Exception
    {
        public WebBrowserException()
        {
        }

        public WebBrowserException(string message) : base(message)
        {
        }

        public WebBrowserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WebBrowserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}