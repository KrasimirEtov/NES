using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradeMarket.Contracts;
using TradeMarket.Providers;

namespace TradeMarket
{
    public class Market : IMarket
    {
        private const string fileWithPrices = "marketPrices";

        private readonly List<IMarketAssetPrice> assetPrices;
		private readonly IMarketStreamManager marketStreamManager;

        public Market(IMarketStreamManager marketStreamManager)
        {
            this.assetPrices = new List<IMarketAssetPrice>();
			this.marketStreamManager = marketStreamManager;
			LoadPrices(fileWithPrices);
		}

        public IList<IMarketAssetPrice>AssetPrices { get => new List<IMarketAssetPrice>(this.assetPrices); }

		public decimal AssetPrice(string assetName)
        {
            var current = this.assetPrices
                .Where(x => x.Name.Equals(assetName))
                .Select(x => x.Price)
                .First();
            return current;
        }
        
        public void UpdatePrices()
        {
            Random random = new Random();
            for (int i = 0; i < this.assetPrices.Count; i++)
            {
                string name = this.assetPrices[i].Name;
                string category = this.assetPrices[i].Category;
                decimal price = this.assetPrices[i].Price + random.Next(1, 20) - random.Next(1, 15) > 0
                    ? this.assetPrices[i].Price + random.Next(1, 20) - random.Next(1, 15)
                    : 0.1m;

                this.assetPrices[i] = new MarketAssetPrice(name, price, category);
            }
            
            SavePrices(fileWithPrices);
        }


        private void SavePrices(string filename)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var asset in this.assetPrices)
            {
                sb.AppendLine($"{asset.Name} {asset.Price} {asset.Category}");
            }

			this.marketStreamManager.WriteLine(sb.ToString().Trim(), filename);
        }

        private void LoadPrices(string filename)
        {
            foreach (string line in this.marketStreamManager.ReadLine(filename))
            {
                string[] lineArr = line.ToLower().Split();
                this.assetPrices.Add(new MarketAssetPrice(lineArr[0], decimal.Parse(lineArr[1]), lineArr[2]));
            }
        }
    }
}
