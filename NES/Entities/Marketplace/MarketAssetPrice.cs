using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Marketplace
{
    public struct MarketAssetPrice
    {
        public MarketAssetPrice(string name, decimal price, string category) : this()
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
