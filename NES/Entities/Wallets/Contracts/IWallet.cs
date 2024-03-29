﻿using NES.Entities.Assets.Contracts;
using System.Collections.Generic;

namespace NES.Entities.Wallets.Contracts
{
	public interface IWallet
	{
		decimal Cash { get; set; }
		void AddAsset(IAsset asset);
        void RemoveAsset(IAsset asset);
		Dictionary<string, IAsset> Portfolio { get; }
	}
}
