﻿using NES.Core.Providers;
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
        private const string fileWithPrices = "marketPrices";

        private List<MarketAssetPrice> assetPrices;
        private static readonly IMarket InstanceHolder = new Market();

        private Market()
        {
            this.assetPrices = new List<MarketAssetPrice>();
            LoadPrices(fileWithPrices);
        }

        public static IMarket Instance
        {
            get => InstanceHolder;
        }

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

        public void PrintMarket()
        {

            StringBuilder sb = new StringBuilder();


        }

        private void SavePrices(string filename)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var asset in this.assetPrices)
            {
                sb.AppendLine($"{asset.Name} {asset.Price} {asset.Category}");
            }

            IOStream.WriteLine(sb.ToString().Trim(), filename);
        }

        private void LoadPrices(string filename)
        {
            foreach (string line in IOStream.ReadLine(filename))
            {
                string[] lineArr = line.ToLower().Split();
                this.assetPrices.Add(new MarketAssetPrice(lineArr[0], decimal.Parse(lineArr[1]), lineArr[2]));
            }
        }
    }
}
