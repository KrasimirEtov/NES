using System.Collections.Generic;

namespace NES.Entities.Users.Contracts
{
	public interface IUserHandler
	{
		IUser RegisteUser(IList<string> parameters);
		IUser LoginUser(IList<string> parameters);
	}
}
