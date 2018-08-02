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
		private decimal cash;

        public Wallet(decimal cash)
        {
            this.portfolio = new Dictionary<string, IAsset>();
			Cash = cash;
        }

		public decimal Cash
		{
			get => cash;
			set
			{
				if (value < 1) throw new ArgumentOutOfRangeException("You are broke!");
				cash = value;
			}
		}

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
