// <copyright file="ColorConsole.cs" company="ColoredConsole contributors">
//  Copyright (c) ColoredConsole contributors. (coloredconsole@gmail.com)
// </copyright>

namespace ColoredConsole
{
    public static class ColorConsole
    {
        private static readonly object @lock = new object();
        private static IConsole console = new SystemConsole();

        public static IConsole Console
        {
            get
            {
                return console;
            }

            set
            {
                Guard.AgainstNullArgument("value", value);

                lock (@lock)
                {
                    console = value;
                }
            }
        }

        public static void Write(params ColorToken[] tokens)
        {
            if (tokens == null || tokens.Length == 0)
            {
                return;
            }

            lock (@lock)
            {
                foreach (var token in tokens)
                {
                    if (token.Color.HasValue || token.BackgroundColor.HasValue)
                    {
                        var originalColor = console.ForegroundColor;
                        var originalBackgroundColor = console.BackgroundColor;
                        try
                        {
                            console.ForegroundColor = token.Color ?? originalColor;
                            console.BackgroundColor = token.BackgroundColor ?? originalBackgroundColor;
                            console.Write(token.Text);
                        }
                        finally
                        {
                            console.ForegroundColor = originalColor;
                            console.BackgroundColor = originalBackgroundColor;
                        }
                    }
                    else
                    {
                        console.Write(token.Text);
                    }
                }
            }
        }

        public static void WriteLine(params ColorToken[] tokens)
        {
            lock (@lock)
            {
                Write(tokens);
                console.WriteLine();
            }
        }
    }
}
