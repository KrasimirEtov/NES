using NES.Entities.Users.Contracts;

namespace NES.Entities.Marketplace.Contracts
{
	public interface IMarket
	{
		decimal AssetPrice(string assetName);
		void UpdatePrices();
        void PrintMarket(IUser user);
	}
}
