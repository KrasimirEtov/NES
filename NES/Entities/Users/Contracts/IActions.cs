using NES.Entities.Wallets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Users.Contracts
{
    public interface IActions
    {
		void Buy();
		void Sell();
		IWallet Wallet { get; }
    }
}
