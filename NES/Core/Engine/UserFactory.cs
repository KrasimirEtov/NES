using NES.Core.Engine.Contracts;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;
using NES.Entities.Wallets;
using NES.Entities.Wallets.Contracts;

namespace NES.Core.Engine
{
    public class UserFactory : IUserFactory
    {
        private readonly static IUserFactory instance = new UserFactory();

        private UserFactory()
		{
		}

		public static IUserFactory Instance { get; } = instance;

		public IUser CreateUser(string name, IWallet wallet)
        {
            return new User(name, wallet);
        }
	}
}
