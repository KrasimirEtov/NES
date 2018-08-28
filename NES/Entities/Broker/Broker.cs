using System;
using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users.Contracts;
using TradeMarket.Contracts;

namespace NES.Entities.Broker
{
	public class Broker : IBroker
	{
		private IAssetFactory Factory { get; set; }
		private IMarket MarketProp { get; set; }
		private IOManager ConsoleManager { get; }
		private IPrinterManager PrinterManager { get; }
		private IUserSession UserSession { get; }

		public Broker(IAssetFactory factory, IMarket market, IOManager consoleManager, IPrinterManager printerManager, IUserSession userSession)
		{
			this.Factory = factory;
			this.MarketProp = market;
			ConsoleManager = consoleManager;
			PrinterManager = printerManager;
			UserSession = userSession;
		}

		public string EndDayTraiding()
		{
			MarketProp.UpdatePrices();
			PrinterManager.PrintMarket();
			return "Trading day has ended!";
		}

		public string Buy(string assetName, decimal amount)
		{
			decimal price = MarketProp.AssetPrice(assetName);

			if (UserSession.User.Wallet.Cash >= price * amount)
			{
				IAsset asset = Factory.CreateAsset(assetName, price, amount);
				UserSession.User.Wallet.AddAsset(asset);
				UserSession.User.Wallet.Cash -= price * amount;
			}
			else
			{
				throw new ArgumentException("You don't have enough funds for this purchase.");
			}
			PrinterManager.PrintMarket();
			return $"Succesfully purchased {amount} {assetName} " + (amount > 1 ? "assets" : "asset");
		}

		public string Sell(string assetName, decimal amount)
		{
			decimal price = MarketProp.AssetPrice(assetName);

			IAsset asset = Factory.CreateAsset(assetName, price, amount);
			
			UserSession.User.Wallet.RemoveAsset(asset);
			UserSession.User.Wallet.Cash += price * amount;
			PrinterManager.PrintMarket();
			return $"Succesfully selled {amount} {assetName} " + (amount > 1 ? "assets" : "asset");
		}
	}
}