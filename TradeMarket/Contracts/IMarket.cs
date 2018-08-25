using System.Collections.Generic;

namespace TradeMarket.Contracts
{
	public interface IMarket
    {
        IList<IMarketAssetPrice> AssetPrices { get; }
        decimal AssetPrice(string assetName);
		void UpdatePrices();
	}
}
