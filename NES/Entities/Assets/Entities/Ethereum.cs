using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Ethereum : Asset
    {
        public const string name = "Ethereum";
        public const string id = "ETH";
        public Ethereum(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
