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
		private IMarket market;
		private IFactory factory;

		public Broker()
		{
			this.factory = AssetFactory.Instance;
			this.market = Market.Instance;
		}

		public void EndDayTraiding()
		{
			market.UpdatePrices();
		}

		public void Buy(string assetName, decimal amount, IUser user)
		{
			decimal price = market.AssetPrice(assetName);

			if (user.Wallet.Cash >= price * amount)
			{
				IAsset asset = factory.CreateAsset(assetName, price, amount);
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
            decimal price = market.AssetPrice(assetName);

            IAsset asset = factory.CreateAsset(assetName, price, amount);
            user.Wallet.RemoveAsset(asset);

            user.Wallet.Cash += price * amount;

        }
    }
}