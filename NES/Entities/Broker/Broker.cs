using NES.Core.Engine;
using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Marketplace.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Broker
{
    public class Broker : IBroker
    {
        private IMarket market;
        private IFactory factory;

        public Broker()
        {
			this.factory = AssetFactory.Instance;
        }

        public void BuyBTC(decimal amount, IUser user)
        {
            //decimal price = market.btc.parice
            decimal price = 10;
            if (user.Wallet.Cash >= price * amount)
            {
                IAsset asset = factory.CreateBitcoin(price, amount);
                user.Wallet.AddAsset(asset);
            }
            else
            {
                throw new ArgumentException("You don't have enough funds for this purchase.");
            }
        }

        public void BuyETH (decimal amount, IUser user)
        {
            //decimal price = market.eth.price;
            
            //if (user.Cash >= price * amount)
            //{
            //    IAsset asset = factory.CreateBitcoin(price, amount);
            //    //user.Wallet.AddAsset(asset);
            //}
            else
            {
                throw new ArgumentException("You don't have enough funds for this purchase.");
            }
        }
    }
}
