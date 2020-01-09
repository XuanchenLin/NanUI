// <copyright file="ColorTokenExtensions.cs" company="ColoredConsole contributors">
//  Copyright (c) ColoredConsole contributors. (coloredconsole@gmail.com)
// </copyright>

namespace ColoredConsole
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Convenience extension methods for re-coloring instances of <see cref="ColorToken"/>.
    /// </summary>
    public static class ColorTokenExtensions
    {
        public static ColorToken[] Mask(this IEnumerable<ColorToken> tokens, ConsoleColor color)
        {
            return tokens.Mask(color, null);
        }

        public static ColorToken[] Mask(this IEnumerable<ColorToken> tokens, ConsoleColor? color, ConsoleColor? backgroundColor)
        {
            return tokens == null ? null : tokens.Select(token => token.Mask(color, backgroundColor)).ToArray();
        }

        public static ColorToken On(this ColorToken token, ConsoleColor? backgroundColor)
        {
            return new ColorToken(token.Text, token.Color, backgroundColor);
        }

        public static ColorToken OnBlack(this ColorToken token)
        {
            return token.On(ConsoleColor.Black);
        }

        public static ColorToken OnBlue(this ColorToken token)
        {
            return token.On(ConsoleColor.Blue);
        }

        public static ColorToken OnCyan(this ColorToken token)
        {
            return token.On(ConsoleColor.Cyan);
        }

        public static ColorToken OnDarkBlue(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkBlue);
        }

        public static ColorToken OnDarkCyan(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkCyan);
        }

        public static ColorToken OnDarkGray(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkGray);
        }

        public static ColorToken OnDarkGreen(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkGreen);
        }

        public static ColorToken OnDarkMagenta(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkMagenta);
        }

        public static ColorToken OnDarkRed(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkRed);
        }

        public static ColorToken OnDarkYellow(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkYellow);
        }

        public static ColorToken OnGray(this ColorToken token)
        {
            return token.On(ConsoleColor.Gray);
        }

        public static ColorToken OnGreen(this ColorToken token)
        {
            return token.On(ConsoleColor.Green);
        }

        public static ColorToken OnMagenta(this ColorToken token)
        {
            return token.On(ConsoleColor.Magenta);
        }

        public static ColorToken OnRed(this ColorToken token)
        {
            return token.On(ConsoleColor.Red);
        }

        public static ColorToken OnWhite(this ColorToken token)
        {
            return token.On(ConsoleColor.White);
        }

        public static ColorToken OnYellow(this ColorToken token)
        {
            return token.On(ConsoleColor.Yellow);
        }

        [SuppressMessage(
            "Microsoft.Naming",
            "CA1719:ParameterNamesShouldNotMatchMemberNames",
            MessageId = "1#",
            Justification = "By design.")]
        public static ColorToken Color(this ColorToken token, ConsoleColor? color)
        {
            return new ColorToken(token.Text, color, token.BackgroundColor);
        }

        public static ColorToken Black(this ColorToken token)
        {
            return token.Color(ConsoleColor.Black);
        }

        public static ColorToken Blue(this ColorToken token)
        {
            return token.Color(ConsoleColor.Blue);
        }

        public static ColorToken Cyan(this ColorToken token)
        {
            return token.Color(ConsoleColor.Cyan);
        }

        public static ColorToken DarkBlue(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkBlue);
        }

        public static ColorToken DarkCyan(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkCyan);
        }

        public static ColorToken DarkGray(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkGray);
        }

        public static ColorToken DarkGreen(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkGreen);
        }

        public static ColorToken DarkMagenta(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkMagenta);
        }

        public static ColorToken DarkRed(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkRed);
        }

        public static ColorToken DarkYellow(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkYellow);
        }

        public static ColorToken Gray(this ColorToken token)
        {
            return token.Color(ConsoleColor.Gray);
        }

        public static ColorToken Green(this ColorToken token)
        {
            return token.Color(ConsoleColor.Green);
        }

        public static ColorToken Magenta(this ColorToken token)
        {
            return token.Color(ConsoleColor.Magenta);
        }

        public static ColorToken Red(this ColorToken token)
        {
            return token.Color(ConsoleColor.Red);
        }

        public static ColorToken White(this ColorToken token)
        {
            return token.Color(ConsoleColor.White);
        }

        public static ColorToken Yellow(this ColorToken token)
        {
            return token.Color(ConsoleColor.Yellow);
        }
    }
}
