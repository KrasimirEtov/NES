using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Wallets.Contracts
{
	public interface IWallet
    {
		decimal Cash { get; }
    }
}
