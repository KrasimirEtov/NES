using NES.Entities.Wallets.Contracts;

namespace NES.Entities.Users.Contracts
{
	public interface IUser
	{
		string Name { get; }
		int Age { get; }
		IWallet Wallet { get; }
	}
}
