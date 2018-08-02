using NES.Core.Providers;
using NES.Entities.Assets.Contracts;
using NES.Entities.Marketplace.Contracts;
using System;
using System.Collections.Generic;
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
            decimal randomNumber = 0;
            foreach (string key in this.assetPrices.Keys)
            {
                this.assetPrices[key] += random.Next(1, 20);
                randomNumber = random.Next(1, 15);
                if (this.assetPrices[key] - randomNumber < 0)
                {
                    this.assetPrices[key] -= randomNumber;
                }                
            }

            SavePrices(fileWithPrices);
        }

        private void SavePrices(string filename)
        {
            foreach (string key in this.assetPrices.Keys)
            {
                IOStream.WriteLine($"{key} {this.assetPrices[key].ToString()}", filename);
            }
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
