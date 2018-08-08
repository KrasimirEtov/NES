using System;
using System.Collections.Generic;
using System.Text;
using NES.Core.Providers;

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
		}

		public static void SetScreenSize()
		{
			Console.WindowHeight = 30;
			Console.BufferWidth = Console.WindowWidth = 120;
		}

		public static void PrintMarketName()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(IOStream.ReadAllText(marketName));
			Console.ResetColor();
		}

		public static void InitialInstructions()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			PrintStartup();
			IOConsole.WriteLine("If you already have an account, please use command 'login' followed by user name and password separated by space.\n");
            IOConsole.WriteLine("If you don't have an account, please create one using command 'register'\nfollowed by user name, password and money for traiding separated by space.");
		}
        
    }
}
