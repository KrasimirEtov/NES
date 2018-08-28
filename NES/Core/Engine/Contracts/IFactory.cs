using NES.Entities.Assets.Contracts;

namespace NES.Core.Engine.Contracts
{
	public interface IAssetFactory
	{
		IAsset CreateAsset(string type, decimal price, decimal amount);
	}
}
