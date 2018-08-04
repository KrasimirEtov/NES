using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Litecoin : Asset
    {
        public const string name = "Litecoin";
        public const string id = "LTC";
        public Litecoin(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
