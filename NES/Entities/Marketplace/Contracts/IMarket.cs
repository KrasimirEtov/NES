using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Marketplace.Contracts
{
	public interface IMarket
    {
        decimal AssetPrice(string assetName);
        void UpdatePrices();
    }
}
