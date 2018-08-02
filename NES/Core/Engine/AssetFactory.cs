using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Users.Contracts;
using NES.Entities.Assets.Entities;
using NES.Entities.Users;

namespace NES.Core.Engine
{
	public class AssetFactory : IFactory
	{
		private static IFactory InstanceHolder = new AssetFactory();

		private AssetFactory()
		{

		}

		public static IFactory Instance
		{
			get => InstanceHolder;
		}

		public IAsset CreateBitcoin(decimal price, decimal amount)
		{
			return new Bitcoin(price, amount);
		}

		public IAsset CreateEtherium(decimal price, decimal amount)
		{
			return new Ethereum(price, amount);
		}
		public IAsset CreateLitecoin(decimal price, decimal amount)
		{
			return new Litecoin(price, amount);
		}

		public IAsset CreateFacebookStock(decimal price, decimal amount)
		{
			return new FacebookStock(price, amount);
		}

		public IAsset CreateGoogleStock(decimal price, decimal amount)
		{
			return new GoogleStock(price, amount);
		}

		public IAsset CreateNetflixStock(decimal price, decimal amount)
		{
			return new NetflixStock(price, amount);
		}

		public IAsset CreateGold(decimal price, decimal amount)
		{
			return new Gold(price, amount);
		}

		public IAsset CreateSilver(decimal price, decimal amount)
		{
			return new Silver(price, amount);
		}

		public IAsset CreatePlatinum(decimal price, decimal amount)
		{
			return new Platinum(price, amount);
		}

		public IUser CreateUser(string name, int age, decimal cash)
		{
			return new User(name, age, cash); // need to do login logic
		}
	}
}
