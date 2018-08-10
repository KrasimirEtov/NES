using System;

namespace NES.Core.Providers
{
	public static class IOConsole
	{
		public static string ReadLine()
		{
			return Console.ReadLine();
		}

		public static void Write(string message, ConsoleColor color = ConsoleColor.White)
		{
            ChangeColor(color);
            Console.Write(message);
            ResetColor();
        }

		public static void WriteLine(string message = "", ConsoleColor color = ConsoleColor.White)
        {
            ChangeColor(color);
            Console.WriteLine(message);
            ResetColor();
        }

		public static void ChangeColor(ConsoleColor console)
		{
			Console.ForegroundColor = console;
		}

		public static void ResetColor()
		{
            ChangeColor(ConsoleColor.White);
		}

		public static void Clear()
		{
			Console.Clear();
		}

		public static void SetScreenSize()
		{
			Console.WindowHeight = 30;
			Console.BufferWidth = Console.WindowWidth = 120;
		}

        public static void WriteAligned(string spacing, string value)
        {
            Console.Write(spacing, value);
        }
    }
}
