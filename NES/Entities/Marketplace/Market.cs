using NES.Core.Providers;
using NES.Entities.Marketplace.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES.Entities.Marketplace
{
    public class Market : IMarket
    {
        private readonly static IMarket instance = new Market();
        private const string fileWithPrices = "marketPrices";

        private readonly List<MarketAssetPrice> assetPrices;

		public static IMarket Instance { get; } = instance;

		private Market()
        {
            this.assetPrices = new List<MarketAssetPrice>();
            LoadPrices(fileWithPrices);
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

        public void PrintMarket(IUser user)
        {
            IOConsole.Clear();
            Printer.PrintMarketName();
            List<MarketAssetPrice> ordered = this.assetPrices.OrderBy(x => x.Category).ToList();
            string category = "";
			Printer.PrintUserInfo(user);

			for (int i = 0; i < ordered.Count; i++)
            {
                if (ordered[i].Category != category)
                {
                    IOConsole.WriteLine();
                    category = ordered[i].Category;
                    IOConsole.WriteAligned("\n{0,20} => ", category);
                }

                IOConsole.WriteAligned("{0,15} ", $"{ordered[i].Name}: ");
                string key = ordered[i].Name.First().ToString().ToUpper() + ordered[i].Name.Substring(1);
                if (user.Wallet.Portfolio.ContainsKey(key))
                {
                    if (user.Wallet.Portfolio[key].Price < ordered[i].Price)
                    {
                        IOConsole.ChangeColor(ConsoleColor.Green);
                    }
                    else if (user.Wallet.Portfolio[key].Price > ordered[i].Price)
                    {
                        IOConsole.ChangeColor(ConsoleColor.Red);
                    }
                }

                IOConsole.WriteAligned("{0,7 } ", $"${ordered[i].Price}");

                IOConsole.ResetColor();
                IOConsole.Write("| ");
            }
            IOConsole.WriteLine("\n");
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
