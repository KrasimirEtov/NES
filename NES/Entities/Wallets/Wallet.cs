using System;
using System.Collections.Generic;
using System.Linq;
using NES.Entities.Assets.Contracts;
using NES.Entities.Wallets.Contracts;

namespace NES.Entities.Wallets
{
	[Serializable]
	public class Wallet : IWallet
	{
		private Dictionary<string, IAsset> portfolio;
		private decimal cash;
        
		public Dictionary<string, IAsset> Portfolio
		{
			get
			{
                return new Dictionary<string, IAsset>(this.portfolio.OrderBy(x => x.Value.Type).ThenBy(x => x.Key));
			}
		}

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
				decimal price = ((this.portfolio[asset.Name].Price * this.portfolio[asset.Name].Amount) + (asset.Price * asset.Amount)) / (this.portfolio[asset.Name].Amount + asset.Amount);
				this.portfolio[asset.Name].Price = price;
				this.portfolio[asset.Name].Amount += asset.Amount;
			}
			else
			{
				this.portfolio[asset.Name] = asset;
			}
		}

        public void RemoveAsset(IAsset asset)
        {
            if (!portfolio.ContainsKey(asset.Name))
            {
                throw new ArgumentException("You can't sell what you don't have.");
            }
            else if ((this.portfolio[asset.Name].Amount - asset.Amount) < 0)
            {
                throw new ArgumentException($"You can't sell {asset.Amount} assets of {asset.Name} because you have {this.portfolio[asset.Name].Amount}.");
            }
            else if ((this.portfolio[asset.Name].Amount - asset.Amount) == 0)
            {
                this.portfolio.Remove(asset.Name);
            }
            else
            {
                this.portfolio[asset.Name].Amount -= asset.Amount;
            }
        }
	}
}