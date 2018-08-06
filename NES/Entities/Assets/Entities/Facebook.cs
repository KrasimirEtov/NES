using NES.Entities.Assets.Enums;
using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Facebook : Asset
    {
        public const string name = "Facebook";
        public Facebook(decimal price, decimal amount) : base(name, AssetType.STOCK, price, amount)
        {

        }
    }
}
