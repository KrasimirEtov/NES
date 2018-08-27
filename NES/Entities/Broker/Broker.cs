using System;
using System.Collections.Generic;
using System.Linq;
using NES.Core.Engine.Contracts;
using NES.Core.Providers;
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

		public Broker(IAssetFactory factory, IMarket market, IOManager consoleManager, IPrinterManager printerManager)
		{
			this.Factory = factory;
			this.MarketProp = market;
			ConsoleManager = consoleManager;
			PrinterManager = printerManager;
		}

		public string EndDayTraiding(IUser user)
		{
			MarketProp.UpdatePrices();
			PrinterManager.PrintMarket(user, MarketProp);
			return "Trading day has ended!";
		}

		public string Buy(string assetName, decimal amount, IUser user)
		{
			decimal price = MarketProp.AssetPrice(assetName);

			if (user.Wallet.Cash >= price * amount)
			{
				IAsset asset = Factory.CreateAsset(assetName, price, amount);
				user.Wallet.AddAsset(asset);
				user.Wallet.Cash -= price * amount;
			}
			else
			{
				throw new ArgumentException("You don't have enough funds for this purchase.");
			}
			PrinterManager.PrintMarket(user, MarketProp);
			return $"Succesfully purchased {amount} {assetName} " + (amount > 1 ? "assets" : "asset");
		}

		public string Sell(string assetName, decimal amount, IUser user)
		{
			decimal price = MarketProp.AssetPrice(assetName);

			IAsset asset = Factory.CreateAsset(assetName, price, amount);
			user.Wallet.RemoveAsset(asset);
			user.Wallet.Cash += price * amount;
			PrinterManager.PrintMarket(user, MarketProp);
			return $"Succesfully selled {amount} {assetName} " + (amount > 1 ? "assets" : "asset");
		}
	}
}