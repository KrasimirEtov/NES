using NES.Core.Engine;
using System;
using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Marketplace;
using NES.Entities.Marketplace.Contracts;
using NES.Entities.Users.Contracts;

namespace NES.Entities.Broker
{
	public class Broker : IBroker
	{
		private IFactory Factory { get; set; } = AssetFactory.Instance;
		private IMarket MarketProp { get; set; } = Market.Instance;

		public Broker()
		{

		}

		public void EndDayTraiding(IUser user)
		{
			MarketProp.UpdatePrices();
			MarketProp.PrintMarket(user);
			user.Wallet.Cash += 5; // we can remove this. I added it so user can gain more money over time without selling
		}

		public void Buy(string assetName, decimal amount, IUser user)
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

			MarketProp.PrintMarket(user);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"Succesfully purchased {amount} {assetName} " + (amount > 1 ? "assets" : "asset"));
			Console.ResetColor();
		}

        public void Sell(string assetName, decimal amount, IUser user)
        {
			decimal price = MarketProp.AssetPrice(assetName);

            IAsset asset = Factory.CreateAsset(assetName, price, amount);
            user.Wallet.RemoveAsset(asset);

            user.Wallet.Cash += price * amount;

			MarketProp.PrintMarket(user); 
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"Succesfully selled {amount} {assetName} " + (amount > 1 ? "assets" : "asset"));
			Console.ResetColor();
		}
    }
}