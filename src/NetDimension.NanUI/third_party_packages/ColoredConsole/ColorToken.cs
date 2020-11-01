// <copyright file="ColorToken.cs" company="ColoredConsole contributors">
//  Copyright (c) ColoredConsole contributors. (coloredconsole@gmail.com)
// </copyright>

namespace ColoredConsole
{
    using System;

    public struct ColorToken : IEquatable<ColorToken>
    {
        private readonly string text;
        private readonly ConsoleColor? color;
        private readonly ConsoleColor? backgroundColor;

        public ColorToken(string text)
            : this(text, null, null)
        {
        }

        public ColorToken(string text, ConsoleColor? color)
            : this(text, color, null)
        {
        }

        public ColorToken(string text, ConsoleColor? color, ConsoleColor? backgroundColor)
        {
            this.text = text;
            this.color = color;
            this.backgroundColor = backgroundColor;
        }

        public string Text
        {
            get { return this.text; }
        }

        public ConsoleColor? Color
        {
            get { return this.color; }
        }

        public ConsoleColor? BackgroundColor
        {
            get { return this.backgroundColor; }
        }

        public static implicit operator ColorToken(string text)
        {
            return new ColorToken(text);
        }

        public static bool operator ==(ColorToken left, ColorToken right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ColorToken left, ColorToken right)
        {
            return !left.Equals(right);
        }

        public ColorToken Mask(ConsoleColor defaultColor)
        {
            return this.Mask(defaultColor, null);
        }

        public ColorToken Mask(ConsoleColor? defaultColor, ConsoleColor? defaultBackgroundColor)
        {
            return new ColorToken(this.text, this.color ?? defaultColor, this.backgroundColor ?? defaultBackgroundColor);
        }

        public override string ToString()
        {
            return this.text;
        }

        public override int GetHashCode()
        {
            return this.text == null ? 0 : this.text.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is ColorToken && this.Equals((ColorToken)obj);
        }

        public bool Equals(ColorToken other)
        {
            return
                this.text == other.text &&
                this.color == other.color &&
                this.backgroundColor == other.backgroundColor;
        }
    }
}
