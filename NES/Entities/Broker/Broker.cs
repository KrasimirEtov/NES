using System;
using NES.Core.Engine;
using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Marketplace.Contracts;
using NES.Entities.Users.Contracts;
using NES.Core.Providers;

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
            MarketProp.PrintMarket(user);

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

			MarketProp.PrintMarket(user);
            return $"Succesfully purchased {amount} {assetName} " + (amount > 1 ? "assets" : "asset");
		}

        public string Sell(string assetName, decimal amount, IUser user)
        {
			decimal price = MarketProp.AssetPrice(assetName);

            IAsset asset = Factory.CreateAsset(assetName, price, amount);
			user.Wallet.RemoveAsset(asset);

            user.Wallet.Cash += price * amount;
			
			MarketProp.PrintMarket(user);
            return $"Succesfully selled {amount} {assetName} " + (amount > 1 ? "assets" : "asset");
		}
    }
}