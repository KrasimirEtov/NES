using NES.Entities.Users.Contracts;

namespace NES.Entities.Users
{
	public class UserSession : IUserSession
	{
		public IUser User { get; set; }

		public void Logout()
		{
			User = null;
		}
	}
}
