using NES.Entities.Assets.Enums;
using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Ethereum : Asset
    {
        public const string name = "Ethereum";
        public Ethereum(decimal price, decimal amount) : base(name, AssetType.CRIPTO, price, amount)
        {

        }
    }
}
