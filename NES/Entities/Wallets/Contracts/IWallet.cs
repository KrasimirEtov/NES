using NES.Entities.Assets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Wallets.Contracts
{
	public interface IWallet
    {
		decimal Cash { get; set; }
		void AddAsset(IAsset asset);
	}
}
