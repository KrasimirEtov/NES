using NES.Entities.Assets.Contracts;
using NES.Entities.Users.Contracts;

namespace NES.Core.Engine.Contracts
{
	public interface IFactory
	{
		IAsset CreateAsset(string type, decimal price, decimal amount);

		IUser CreateUser(string name, int age, decimal cash);
	}
}
