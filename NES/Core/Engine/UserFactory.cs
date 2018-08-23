using NES.Core.Engine.Contracts;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;
using NES.Entities.Wallets;
using NES.Entities.Wallets.Contracts;

namespace NES.Core.Engine
{
    public class UserFactory : IUserFactory
    {
        public UserFactory()
		{
		}

		public IUser CreateUser(string name, IWallet wallet)
        {
            return new User(name, wallet);
        }
	}
}
