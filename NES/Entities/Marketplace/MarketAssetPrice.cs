using System;
using System.Linq;

namespace NES.Entities.Marketplace
{
    public struct MarketAssetPrice
    {
		private string name;
		private decimal price;
		private string category;

        public MarketAssetPrice(string name, decimal price, string category) : this()
        {
            Name = name;
            Price = price;
            this.Category = category;
        }

		public string Name
		{
			get => name;
			set
			{
				if (value.All(char.IsDigit)) throw new ArgumentException("Name cannot contain only letters!");
				if (value == null) throw new ArgumentNullException("Name cannot be null!");
				if (value.Length < 1 || value.Length > 50) throw new Exception("Name length cannot be less than 1 or more than 50 characters!");
				name = value;
			}
		}

		public decimal Price
		{
			get => price;
			set
			{
				if (value < 1) throw new Exception("Price cannot be negative!");
				price = value;
			}
		}

		public string Category
		{
			get => category;
			set
			{
				if (value.All(char.IsDigit)) throw new ArgumentException("Category cannot contain only letters!");
				if (value == null) throw new ArgumentNullException("Category cannot be null!");
				if (value.Length < 1 || value.Length > 50) throw new Exception("Category length cannot be less than 1 or more than 50 characters!");
				category = value;
			}
		}
    }
}
