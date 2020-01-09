// <copyright file="IConsole.cs" company="ColoredConsole contributors">
//  Copyright (c) ColoredConsole contributors. (coloredconsole@gmail.com)
// </copyright>

namespace ColoredConsole
{
    using System;

    public interface IConsole
    {
        ConsoleColor ForegroundColor { get; set; }

        ConsoleColor BackgroundColor { get; set; }

        void Write(string text);

        void WriteLine();
    }
}
