using NES.Entities.Assets.Enums;
using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Litecoin : Asset
    {
        public const string name = "Litecoin";
        public Litecoin(decimal price, decimal amount) : base(name, AssetType.CRIPTO, price, amount)
        {
        }
    }
}
