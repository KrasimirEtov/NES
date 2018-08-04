using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Googlestock : Asset
    {
        public const string name = "Google";
        public const string id = "GOOGL";
        public Googlestock(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
