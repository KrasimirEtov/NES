using NES.Entities.Users.Contracts;
using NES.Entities.Wallets.Contracts;

namespace NES.Core.Engine.Contracts
{
    public interface IUserFactory
    {
		IUser CreateUser(string name, IWallet wallet);
    }
}
