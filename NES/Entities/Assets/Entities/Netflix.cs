using NES.Entities.Assets.Enums;
using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Netflix : Asset
    {
        public const string name = "Netflix";
        public Netflix(decimal price, decimal amount) : base(name, AssetType.STOCK, price, amount)
        {
        }
    }
}
