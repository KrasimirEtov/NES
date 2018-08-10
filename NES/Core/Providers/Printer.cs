using NES.Entities.Users.Contracts;
using System;

namespace NES.Core.Providers
{
    public static class Printer
    {
		private const string welcomeScreen = "Welcome";
		private const string marketName = "MarketName";
		public static void PrintStartup()
		{
			IOConsole.Clear();
			IOConsole.WriteLine(IOStream.ReadAllText(welcomeScreen), ConsoleColor.Blue);
		}

		public static void PrintMarketName()
		{
			IOConsole.WriteLine(IOStream.ReadAllText(marketName), ConsoleColor.Blue);
		}

		public static void InitialInstructions()
		{
			PrintStartup();
			IOConsole.WriteLine("If you already have an account, please use command 'login' followed by user name and password separated by space.\n");
            IOConsole.WriteLine("If you don't have an account, please create one using command 'register'\nfollowed by user name, password and money for traiding separated by space.\n");
		}

		public static void PrintUserInfo(IUser user)
		{
			IOConsole.WriteLine($"User: {user.Name}");
			IOConsole.Write($"Cash: ${user.Wallet.Cash}");
		}       
    }
}
