using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Gold : Asset
    {
        public const string name = "Gold";
        public const string id = "GLD";
        public Gold(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
