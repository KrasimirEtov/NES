using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using TradeMarket.Contracts;

namespace NES.Tests.Mocks
{
    internal class BrokerMock
    {
        private IAssetFactory Factory { get; set; }
        private IMarket MarketProp { get; set; }

        public BrokerMock(IAssetFactory factory, IMarket market)
        {
            this.Factory = factory;
            this.MarketProp = market;
        }

        public string EndDayTraiding(IUser user)
        {
            MarketProp.UpdatePrices();

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

            return $"Succesfully purchased {amount} {assetName} " + (amount > 1 ? "assets" : "asset");
        }

        public string Sell(string assetName, decimal amount, IUser user)
        {
            decimal price = MarketProp.AssetPrice(assetName);

            IAsset asset = Factory.CreateAsset(assetName, price, amount);
            user.Wallet.RemoveAsset(asset);

            user.Wallet.Cash += price * amount;

            return $"Succesfully selled {amount} {assetName} " + (amount > 1 ? "assets" : "asset");
        }
    }
}
