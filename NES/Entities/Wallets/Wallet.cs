using NES.Entities.Assets.Contracts;
using NES.Entities.Wallets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Wallets
{
    public class Wallet : IWallet
    {
        private Dictionary<string, IAsset> portfolio;

        public Wallet()
        {
            this.portfolio = new Dictionary<string, IAsset>();
        }

        public decimal Cash { get; private set; }

        public void AddAsset(IAsset asset)
        {
            if (portfolio.ContainsKey(asset.Name))
            {
                this.portfolio[asset.Name].Amount += asset.Amount;
            }
            else
            {
                this.portfolio[asset.Name] = asset;
            }
        }
    }
}
