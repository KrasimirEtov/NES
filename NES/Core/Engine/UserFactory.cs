using NES.Core.Engine.Contracts;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;

namespace NES.Core.Engine
{
    public class UserFactory : IUserFactory
    {
		private UserFactory()
		{
		}

		public static IUserFactory Instance { get; } = new UserFactory();

		public IUser CreateUser()
		{
			var login = new Login();
			return login.CreateUser();
		}

		public void RegisterUser()
		{
			var reg = new Register();
			reg = null;
		}
	}
}
