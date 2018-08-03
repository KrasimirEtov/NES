using NES.Core.Engine;
using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Marketplace;
using NES.Entities.Marketplace.Contracts;
using NES.Entities.Users.Contracts;
using System;

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

		public void BuyBTC(decimal amount, IUser user)
		{
			decimal price = market.AssetPrice("Bitcoin");

			if (user.Wallet.Cash >= price * amount)
			{
				IAsset bitcoin = factory.CreateBitcoin(price, amount);
				user.Wallet.AddAsset(bitcoin);
			}
			else
			{
				throw new ArgumentException("You don't have enough funds for this purchase.");
			}
		}

		public void BuyETH(decimal amount, IUser user)
        {
            decimal price = market.AssetPrice("Ethereum");

            if (user.Wallet.Cash >= price * amount)
			{
				IAsset ethereum = factory.CreateEtherium(price, amount);
				user.Wallet.AddAsset(ethereum);
			}
			else
			{
				throw new ArgumentException("You don't have enough funds for this purchase.");
			}
		}

		public void BuyGold(decimal amount, IUser user)
        {
            decimal price = market.AssetPrice("Gold");

            if (user.Wallet.Cash >= price * amount)
			{
				IAsset gold = factory.CreateGold(price, amount);
				user.Wallet.AddAsset(gold);
			}
			else
			{
				throw new ArgumentException("You don't have enough funds for this purchase.");
			}
		}

		public void BuySilver(decimal amount, IUser user)
        {
            decimal price = market.AssetPrice("Silver");

            if (user.Wallet.Cash >= price * amount)
			{
				IAsset silver = factory.CreateSilver(price, amount);
				user.Wallet.AddAsset(silver);
			}
			else
			{
				throw new ArgumentException("You don't have enough funds for this purchase.");
			}
		}

		public void BuyFacebookStock(decimal amount, IUser user)
        {
            decimal price = market.AssetPrice("FacebookStock");

            if (user.Wallet.Cash >= price * amount)
			{
				IAsset facebookStock = factory.CreateFacebookStock(price, amount);
				user.Wallet.AddAsset(facebookStock);
			}
			else
			{
				throw new ArgumentException("You don't have enough funds for this purchase.");
			}
		}

		public void BuyGoogleStock(decimal amount, IUser user)
        {
            decimal price = market.AssetPrice("GoogleStock");

            if (user.Wallet.Cash >= price * amount)
			{
				IAsset googleStock = factory.CreateGoogleStock(price, amount);
				user.Wallet.AddAsset(googleStock);
			}
			else
			{
				throw new ArgumentException("You don't have enough funds for this purchase.");
			}
		}

		public void BuyLitecoin(decimal amount, IUser user)
        {
            decimal price = market.AssetPrice("Litecoin");

            if (user.Wallet.Cash >= price * amount)
			{
				IAsset litecoin = factory.CreateLitecoin(price, amount);
				user.Wallet.AddAsset(litecoin);
			}
			else
			{
				throw new ArgumentException("You don't have enough funds for this purchase.");
			}
		}

		public void BuyNetflixStock(decimal amount, IUser user)
        {
            decimal price = market.AssetPrice("NetflixStock");

            if (user.Wallet.Cash >= price * amount)
			{
				IAsset netflix = factory.CreateNetflixStock(price, amount);
				user.Wallet.AddAsset(netflix);
			}
			else
			{
				throw new ArgumentException("You don't have enough funds for this purchase.");
			}
		}

		public void BuyPlatinum(decimal amount, IUser user)
        {
            decimal price = market.AssetPrice("Platinum");

            if (user.Wallet.Cash >= price * amount)
			{
				IAsset platinum = factory.CreatePlatinum(price, amount);
				user.Wallet.AddAsset(platinum);
			}
			else
			{
				throw new ArgumentException("You don't have enough funds for this purchase.");
			}
		}
	}
}