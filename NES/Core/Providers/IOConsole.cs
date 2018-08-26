using NES.Core.Engine.Contracts;
using System;

namespace NES.Core.Providers
{
	public class IOConsole : IConsoleManager
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}

		public void Write(string message, ConsoleColor color = ConsoleColor.White)
		{
			ChangeColor(color);
			Console.Write(message);
			ResetColor();
		}

		public void WriteLine(string message = "", ConsoleColor color = ConsoleColor.White)
		{
			ChangeColor(color);
			Console.WriteLine(message);
			ResetColor();
		}

		public void ChangeColor(ConsoleColor console)
		{
			Console.ForegroundColor = console;
		}

		public void ResetColor()
		{
			ChangeColor(ConsoleColor.White);
		}

		public void Clear()
		{
			Console.Clear();
		}

		public void SetScreenSize()
		{
			Console.WindowHeight = 30;
			Console.BufferWidth = Console.WindowWidth = 120;
		}

		public void WriteAligned(string spacing, string value)
		{
			Console.Write(spacing, value);
		}
	}
}
