using NES.Entities.Assets.Enums;
using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Platinum : Asset
    {
        public const string name = "Platinum";
        public Platinum(decimal price, decimal amount) : base(name, AssetType.METAL, price, amount)
        {

        }
    }
}
