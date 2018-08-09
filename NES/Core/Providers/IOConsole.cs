using System;

namespace NES.Core.Providers
{
	public static class IOConsole
	{
		public static string ReadLine()
		{
			return Console.ReadLine();
		}

		public static void Write(string message)
		{
			Console.Write(message);
		}

		public static void WriteLine(string message)
		{
			Console.WriteLine(message);
		}

		public static void ChangeColor(ConsoleColor console)
		{
			Console.ForegroundColor = console;
		}

		public static void ResetColor()
		{
			Console.ResetColor();
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
	}
}
