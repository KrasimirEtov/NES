using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Netflixstock : Asset
    {
        public const string name = "Netflix";
        public const string id = "NFLX";
        public Netflixstock(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
