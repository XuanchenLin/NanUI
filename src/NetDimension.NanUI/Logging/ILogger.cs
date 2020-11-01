using System;
using System.Collections.Generic;
using System.Text;

namespace NetDimension.NanUI.Logging
{
    public interface ILogger
    {
        void Info(string message);
        void Verbose(string message);
        void Debug(string message);
        void Warn(string message);
        void Critial(string message);
        void Fatal(string message);
        void Error(string message);
        void Error(System.Exception exception);
        void Error(System.Exception exception, string message);

    }
}
