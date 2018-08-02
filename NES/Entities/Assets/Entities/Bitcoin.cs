using NES.Entities.Assets.Contracts;

namespace NES.Entities.Assets.Entities
{
    public class Bitcoin : Asset
    {
		public const string name = "Bitcoin";
		public const string id = "BTC";
		public Bitcoin(decimal price, decimal amount) : base(name, id, price, amount)
		{

		}
    }
}
