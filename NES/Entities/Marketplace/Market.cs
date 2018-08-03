using NES.Core.Providers;
using NES.Entities.Assets.Contracts;
using NES.Entities.Marketplace.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES.Entities.Marketplace
{
    public class Market : IMarket
    {
        private const string fileWithPrices = "marketPrices.txt";

        private readonly Dictionary<string, ICollection<IAsset>> categories;
        private Dictionary<string, decimal> assetPrices;
        private static readonly IMarket InstanceHolder = new Market();

        private Market()
        {
            this.assetPrices = new Dictionary<string, decimal>();
            this.categories = new Dictionary<string, ICollection<IAsset>>();
            LoadPrices(fileWithPrices);
        }

        public static IMarket Instance
        {
            get => InstanceHolder;
        }

        public decimal AssetPrice(string assetName)
        {
            return assetPrices[assetName];
        }
        
        public void UpdatePrices()
        {
            Random random = new Random();
            for (int i = 0; i < this.assetPrices.Count; i++)
            {
                var item = this.assetPrices.ElementAt(i);
                this.assetPrices[item.Key] += random.Next(1, 20) - random.Next(1, 15);
                if (item.Value <= 0)
                {
                    this.assetPrices[item.Key] = 0.1m;
                }
            }
            
            SavePrices(fileWithPrices);
        }

        private void SavePrices(string filename)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var asset in this.assetPrices)
            {
                sb.AppendLine($"{asset.Key} {asset.Value}");
            }

            IOStream.OverrideLine(sb.ToString(), filename);
        }

        private void LoadPrices(string filename)
        {
            foreach (string line in IOStream.ReadLine(filename))
            {
                string[] lineArr = line.Split();
                this.assetPrices[lineArr[0]] = decimal.Parse(lineArr[1]);
            }
        }

    }
}
