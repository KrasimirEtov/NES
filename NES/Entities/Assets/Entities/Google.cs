using NES.Entities.Assets.Enums;
using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Google : Asset
    {
        public const string name = "Google";
        public Google(decimal price, decimal amount) : base(name, AssetType.STOCK, price, amount)
        {
        }
    }
}
