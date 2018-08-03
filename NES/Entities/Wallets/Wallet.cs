using System;
using System.Collections.Generic;
using NES.Entities.Assets.Contracts;
using NES.Entities.Wallets.Contracts;

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
				decimal price = ((this.portfolio[asset.Name].Price * this.portfolio[asset.Name].Amount) + (asset.Price * asset.Amount)) / (this.portfolio[asset.Name].Amount + asset.Amount);
				this.portfolio[asset.Name].Price += price;
				this.portfolio[asset.Name].Amount += asset.Amount;
			}
			else
			{
				this.portfolio[asset.Name] = asset;
			}
		}

		public void PrintWallet()
		{
			foreach (var asset in portfolio)
			{
				Console.WriteLine($"{asset.Key} Amount: {asset.Value.Amount} Price per unit: {asset.Value.Price}");
			}
		}
	}
}