using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Users.Contracts;
using System;
using TradeMarket.Contracts;

namespace NES.Tests.Mocks
{
    internal class BrokerMock
    {
        private IAssetFactory Factory { get; set; }
        private IMarket MarketProp { get; set; }
		private IUserSession UserSession { get; }

		public BrokerMock(IAssetFactory factory, IMarket market, IUserSession userSession)
        {
            this.Factory = factory;
            this.MarketProp = market;
			UserSession = userSession;
		}

        public string EndDayTraiding()
        {
            MarketProp.UpdatePrices();

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

            return $"Succesfully purchased {amount} {assetName} " + (amount > 1 ? "assets" : "asset");
        }

        public string Sell(string assetName, decimal amount)
        {
            decimal price = MarketProp.AssetPrice(assetName);

            IAsset asset = Factory.CreateAsset(assetName, price, amount);
			UserSession.User.Wallet.RemoveAsset(asset);

			UserSession.User.Wallet.Cash += price * amount;

            return $"Succesfully selled {amount} {assetName} " + (amount > 1 ? "assets" : "asset");
        }
    }
}
