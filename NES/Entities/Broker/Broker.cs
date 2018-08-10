using NES.Core.Engine;
using System;
using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Marketplace;
using NES.Entities.Marketplace.Contracts;
using NES.Entities.Users.Contracts;
using NES.Core.Providers;
using NES.Entities.Assets;

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
            IOConsole.ChangeColor(ConsoleColor.Green);
			IOConsole.WriteLine($"Succesfully purchased {amount} {assetName} " + (amount > 1 ? "assets" : "asset"));
			IOConsole.ResetColor();
		}

        public void Sell(string assetName, decimal amount, IUser user)
        {
			decimal price = MarketProp.AssetPrice(assetName);

            IAsset asset = Factory.CreateAsset(assetName, price, amount);
            try
            {
                user.Wallet.TotalWinnings += (price - user.Wallet.Portfolio[asset.Name].Price) * amount; // get total winnings
            }
            catch
            {
                throw new ArgumentException($"Not enough {assetName}s in the wallet.");
            }
			user.Wallet.RemoveAsset(asset);

            user.Wallet.Cash += price * amount;
			
			MarketProp.PrintMarket(user);
            IOConsole.ChangeColor(ConsoleColor.Green);
            IOConsole.WriteLine($"Succesfully selled {amount} {assetName} " + (amount > 1 ? "assets" : "asset"));
			IOConsole.ResetColor();
		}
    }
}