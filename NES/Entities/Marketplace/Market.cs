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
		private const string fileWithPrices = "marketPrices";
		private const string fileWithTempPrices = "marketPricesTemp";
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
			//this.assetPrices.Values.Select(x => x += random.Next(1, 20)).Select(x => x -= random.Next(1, 15)).Where(x => x < 1).Select(x => x = 1);
			foreach (var key in assetPrices.Keys.ToList())
			{
				assetPrices[key] = random.Next(1, 8500);
			}
			SavePrices(fileWithPrices);
		}

		private void SavePrices(string filename)
		{
			StringBuilder allPrices = new StringBuilder();
			foreach (string key in this.assetPrices.Keys)
			{
				allPrices.AppendLine($"{key} {this.assetPrices[key].ToString()}");
			}
			IOStream.WriteLine(allPrices.ToString().TrimEnd(), fileWithPrices);
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