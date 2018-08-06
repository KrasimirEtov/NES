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
		//private IMarket market;

		private IFactory Factory { get; set; } = AssetFactory.Instance;
		private IMarket MarketProp { get; set; } = Market.Instance;

		public Broker()
		{

		}

		public void EndDayTraiding(IUser user)
		{
			MarketProp.UpdatePrices();
            Console.Clear();
			MarketProp.PrintMarket(user);
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
		}

        public void Sell(string assetName, decimal amount, IUser user)
        {
            decimal price = MarketProp.AssetPrice(assetName);

            IAsset asset = Factory.CreateAsset(assetName, price, amount);
            user.Wallet.RemoveAsset(asset);

            user.Wallet.Cash += price * amount;
        }
    }
}