using NES.Entities.Assets.Contracts;
using NES.Entities.Assets.Enums;
using System;

namespace NES.Entities.Assets
{
	[Serializable]
	public abstract class Asset : IAsset
	{
		private string name;
		private AssetType type;
		private decimal price;
		private decimal amount;

		public string Name
		{
			get => name;
			set
			{
				name = value ?? throw new ArgumentNullException("Name cannot be null!");
			}
		}

		public AssetType Type
		{
			get => type;
            set => this.type = value;
		}

		public decimal Price
		{
			get => price;
			set
			{
				if (value < 0) throw new ArgumentOutOfRangeException("Price cannot be negative!");
				price = value;
			}
		}

		public decimal Amount
		{
			get => amount;
			set
			{
				if (value < 0) throw new ArgumentOutOfRangeException("Amount cannot be negative!");
				amount = value;
			}
		}

		public Asset(string name, AssetType type, decimal price, decimal amount)
		{
			Name = name;
            Type = type;
			Price = price;
			Amount = amount;
		}
	}
}