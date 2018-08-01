using NES.Entities.Assets.Contracts;

namespace NES.Entities.Assets.Entities
{
    public class Bitcoin : Asset, IAsset
    {
		public const string name = "Bitcoin";
		public const string id = "BTC";
		public Bitcoin(decimal price, decimal amount) : base(name, id, price, amount)
		{

		}
    }
}
