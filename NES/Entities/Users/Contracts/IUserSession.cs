namespace NES.Entities.Users.Contracts
{
	public interface IUserSession
	{
		IUser User { get; set; }
		void Logout();
		bool IsUserLoggedIn();
	}
}
