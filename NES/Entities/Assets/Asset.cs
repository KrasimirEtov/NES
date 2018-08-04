using NES.Entities.Assets.Contracts;
using System;

namespace NES.Entities.Assets
{
	[Serializable]
	public abstract class Asset : IAsset
	{
		private string name;
		private string id;
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

		public string Id
		{
			get => id;
			set
			{
				id = value ?? throw new ArgumentNullException("ID cannot be null!");
			}
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

		public Asset(string name, string id, decimal price, decimal amount)
		{
			Name = name;
			Id = id;
			Price = price;
			Amount = amount;
		}
	}
}