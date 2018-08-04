using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Facebookstock : Asset
    {
        public const string name = "Facebook";
        public const string id = "FB";
        public Facebookstock(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
