using NES.Core.Engine.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradeMarket.Contracts;

namespace NES.Core.Providers
{
	public class Printer : IPrinterManager
	{
		private const string welcomeScreen = "Welcome";
		private const string marketName = "MarketName";

		private IOManager ConsoleManager { get; }
		private IStreamManager StreamManager { get; }

		public Printer(IOManager consoleManager, IStreamManager streamManager)
		{
			ConsoleManager = consoleManager;
			StreamManager = streamManager;
		}
		public void PrintStartup()
		{
			ConsoleManager.Clear();
			ConsoleManager.WriteLine(StreamManager.ReadAllText(welcomeScreen), ConsoleColor.Blue);
		}

		public void PrintMarketName()
		{
			ConsoleManager.WriteLine(StreamManager.ReadAllText(marketName), ConsoleColor.Blue);
		}

		public void InitialInstructions()
		{
			PrintStartup();
			ConsoleManager.WriteLine("If you already have an account, please use command 'login' followed by user name and password separated by space.\n");
			ConsoleManager.WriteLine("If you don't have an account, please create one using command 'register'\nfollowed by user name, password and money for traiding separated by space.\n");
		}

		public void PrintUserInfo(IUser user)
		{
			ConsoleManager.WriteLine($"User: {user.Name}");
			ConsoleManager.Write($"Cash: ${user.Wallet.Cash}");
		}

		public void PrintMarket(IUser user, IMarket market)
		{
			ConsoleManager.Clear();
			PrintMarketName();
			List<IMarketAssetPrice> ordered = market.AssetPrices.OrderBy(x => x.Category).ToList();
			string category = "";
			PrintUserInfo(user);

			for (int i = 0; i < ordered.Count; i++)
			{
				if (ordered[i].Category != category)
				{
					ConsoleManager.WriteLine();
					category = ordered[i].Category;
					ConsoleManager.WriteAligned("\n{0,20} => ", category);
				}

				ConsoleManager.WriteAligned("{0,15} ", $"{ordered[i].Name}: ");

				string key = ordered[i].Name.First().ToString().ToUpper() + ordered[i].Name.Substring(1);
				if (user.Wallet.Portfolio.ContainsKey(key))
				{
					if (user.Wallet.Portfolio[key].Price < ordered[i].Price)
					{
						ConsoleManager.ChangeColor(ConsoleColor.Green);
					}
					else if (user.Wallet.Portfolio[key].Price > ordered[i].Price)
					{
						ConsoleManager.ChangeColor(ConsoleColor.Red);
					}
				}

				ConsoleManager.WriteAligned("{0,7 } ", $"${ordered[i].Price}");

				ConsoleManager.ResetColor();
				ConsoleManager.Write("| ");
			}
			ConsoleManager.WriteLine("\n");
		}

		public string PrintWallet(IUser user)
		{
			StringBuilder walletString = new StringBuilder();
			string categoty = "";
			if (user.Wallet.Portfolio.Count < 1)
			{
				return "You don't have any purchased assets!";
			}
			foreach (var asset in user.Wallet.Portfolio)
			{
				if (categoty != asset.Value.Type.ToString())
				{
					categoty = asset.Value.Type.ToString();
					walletString.AppendLine("\n" + asset.Value.Type.ToString() + ":");
				}
				walletString.Append($"   {asset.Key}:");
				walletString.AppendLine($" Amount: {asset.Value.Amount}, Price per unit: {asset.Value.Price}");
			}

			return walletString.ToString();
		}
	}
}
