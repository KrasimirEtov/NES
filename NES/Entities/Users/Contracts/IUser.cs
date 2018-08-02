using NES.Entities.Wallets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Users.Contracts
{
    public interface IUser
    {
		string Name { get; }
		int Age { get; }
		IWallet Wallet { get; }
	}
}
