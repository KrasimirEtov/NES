using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Assets.Contracts
{
	public interface IAsset
    {
		string Name { get; }
		string Id { get; }
		decimal Price { get; }
		decimal Amount { get; }


	}
}
