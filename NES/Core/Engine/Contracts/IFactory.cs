using NES.Entities.Assets.Contracts;
using NES.Entities.Users.Contracts;

namespace NES.Core.Engine.Contracts
{
	public interface IFactory
	{
		IAsset CreateBitcoin(decimal price, decimal amount);
		IAsset CreateEtherium(decimal price, decimal amount);
		IAsset CreateLitecoin(decimal price, decimal amount);

		IAsset CreateGold(decimal price, decimal amount);
		IAsset CreateSilver(decimal price, decimal amount);
		IAsset CreatePlatinum(decimal price, decimal amount);

		IAsset CreateFacebookStock(decimal price, decimal amount);
		IAsset CreateGoogleStock(decimal price, decimal amount);
		IAsset CreateNetflixStock(decimal price, decimal amount);

		IUser CreateUser(string name, int age, decimal cash);
	}
}
