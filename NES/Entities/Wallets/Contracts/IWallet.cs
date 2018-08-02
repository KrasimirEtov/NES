using NES.Entities.Assets.Contracts;

namespace NES.Entities.Wallets.Contracts
{
	public interface IWallet
	{
		decimal Cash { get; set; }
		void AddAsset(IAsset asset);
		void PrintWallet();
	}
}
