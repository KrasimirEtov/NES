using NES.Entities.Assets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Assets
{
    public abstract class Asset : IAsset
    {
		private string name;
		private string id;
		private decimal price;
		private decimal amount;

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public string Id
		{
			get
			{
				return id;

			}
			set
			{
				id = value;
			}
		}

		public decimal Price
		{
			get
			{
				return price;
			}
			set
			{
				price = value;
			}
		}

		public decimal Amount
		{
			get
			{
				return amount;
			}
			set
			{
				amount = value;
			}
		}

		protected Asset(string name, string id, decimal price, decimal amount)
		{
			Name = name;
			Id = id;
			Price = price;
			Amount = amount;
		}
	}
}
