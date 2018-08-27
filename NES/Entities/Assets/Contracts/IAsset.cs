using NES.Entities.Assets.Enums;

namespace NES.Entities.Assets.Contracts
{
	public interface IAsset
    {
		string Name { get; }
        AssetType Type { get; set; }
		decimal Price { get; set; }
		decimal Amount { get; set; }
	}
}
