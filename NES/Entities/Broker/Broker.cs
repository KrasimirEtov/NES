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

		public Broker(IAssetFactory factory, IMarket market)
		{
            this.Factory = factory;
            this.MarketProp = market;
		}

		public string EndDayTraiding(IUser user)
		{
			MarketProp.UpdatePrices();
            this.PrintMarket(user);

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

			this.PrintMarket(user);
            return $"Succesfully purchased {amount} {assetName} " + (amount > 1 ? "assets" : "asset");
		}

        public string Sell(string assetName, decimal amount, IUser user)
        {
			decimal price = MarketProp.AssetPrice(assetName);

            IAsset asset = Factory.CreateAsset(assetName, price, amount);
			user.Wallet.RemoveAsset(asset);

            user.Wallet.Cash += price * amount;
			
			this.PrintMarket(user);
            return $"Succesfully selled {amount} {assetName} " + (amount > 1 ? "assets" : "asset");
		}

        private void PrintMarket(IUser user)
        {
            IOConsole.Clear();
            Printer.PrintMarketName();
            List<IMarketAssetPrice> ordered = MarketProp.AssetPrices.OrderBy(x => x.Category).ToList();
            string category = "";
            Printer.PrintUserInfo(user);

            for (int i = 0; i < ordered.Count; i++)
            {
                if (ordered[i].Category != category)
                {
                    IOConsole.WriteLine();
                    category = ordered[i].Category;
                    IOConsole.WriteAligned("\n{0,20} => ", category);
                }

                IOConsole.WriteAligned("{0,15} ", $"{ordered[i].Name}: ");
                string key = ordered[i].Name.First().ToString().ToUpper() + ordered[i].Name.Substring(1);
                if (user.Wallet.Portfolio.ContainsKey(key))
                {
                    if (user.Wallet.Portfolio[key].Price < ordered[i].Price)
                    {
                        IOConsole.ChangeColor(ConsoleColor.Green);
                    }
                    else if (user.Wallet.Portfolio[key].Price > ordered[i].Price)
                    {
                        IOConsole.ChangeColor(ConsoleColor.Red);
                    }
                }

                IOConsole.WriteAligned("{0,7 } ", $"${ordered[i].Price}");

                IOConsole.ResetColor();
                IOConsole.Write("| ");
            }
            IOConsole.WriteLine("\n");
        }

    }
}