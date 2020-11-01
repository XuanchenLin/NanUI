using System;
using System.Collections.Generic;
using System.Text;

namespace NetDimension.NanUI.Logging
{
    using ColoredConsole;

    using static ColoredConsole.ColorConsole;

    public class DefaultLogger : ILogger
    {
        public void Critial(string message)
        {
            WriteLine(Now, " ", $"[{nameof(Critial)}]".Cyan(), " ", message.Magenta());
        }

        public void Debug(string message)
        {
            WriteLine(Now, " ", $"[{nameof(Debug)}]".Cyan(), " ", message.DarkCyan());
        }

        public void Error(string message)
        {
            WriteLine(Now, " ", $"[{nameof(Error)}]".Cyan(), " ", message.Red());
        }

        public void Error(Exception exception)
        {
            WriteLine(Now, " ", " ", $"[{nameof(Error)}]".Cyan(), " ", exception.Message.Red());

            WriteLine($"{exception}".DarkGray());

        }

        public void Error(Exception exception, string message)
        {
            WriteLine(Now, " ", $"[{nameof(Error)}]".Cyan(), " ", message.Red());

            WriteLine($"{exception}".DarkGray());
        }

        public void Fatal(string message)
        {
            WriteLine(Now, " ", $"[{nameof(Fatal)}]".Cyan(), " ", $" {message} ".White().OnDarkRed());
        }

        public void Info(string message)
        {
            WriteLine(Now, " ", $"[{nameof(Info)}]".Cyan(), " ", message.White());
        }

        public void Verbose(string message)
        {
            //WriteLine("-> ".White());
            WriteLine(message.DarkGray());
        }

        public void Warn(string message)
        {
            WriteLine(Now, " ", $"[{nameof(Warn)}]".Cyan(), " ", message.Yellow());
        }

        private ColorToken Now => string.Format("[{0:yyyy-MM-dd HH:mm:ss}]", DateTime.Now).DarkGreen();
    }
}
