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
        private readonly Dictionary<string, ICollection<IAsset>> categories;
        private Dictionary<string, decimal> assetPrices;
        private static readonly IMarket InstanceHolder = new Market();
        private IOStream stream;

        private Market()
        {
            this.assetPrices = new Dictionary<string, decimal>();
            this.categories = new Dictionary<string, ICollection<IAsset>>();
            this.stream = new IOStream();
            LoadPrices("marketPrices.txt");
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
            throw new NotImplementedException();
        }

        public void SavePrices()
        {
            throw new NotImplementedException();
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
