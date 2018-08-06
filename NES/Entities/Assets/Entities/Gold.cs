using NES.Entities.Assets.Enums;
using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Gold : Asset
    {
        public const string name = "Gold";
        public Gold(decimal price, decimal amount) : base(name, AssetType.METAL, price, amount)
        {

        }
    }
}
