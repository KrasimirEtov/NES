using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Providers
{
    public static class Printer
    {
		private const string welcomeScreen = "Welcome";
		private const string marketName = "MarketName";
		public static void PrintStartup()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(IOStream.ReadAllText(welcomeScreen));
			Console.ResetColor();
			Console.CursorVisible = false;
		}

		public static void SetScreenSize()
		{
			Console.BufferHeight = Console.WindowHeight = 30;
			Console.BufferWidth = Console.WindowWidth = 120;
		}

		public static void PrintMarketName()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(IOStream.ReadAllText(marketName));
			Console.ResetColor();
			Console.CursorVisible = false;
		}

		public static void InitialInstructions()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			PrintStartup();
			Console.WriteLine("If you already have an account, please use command 'login'.");
			Console.WriteLine("If you don't have an account, please create one using command 'register'.\n");
		}

	}
}
