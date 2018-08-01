using NES.Entities.Assets.Contracts;

namespace NES.Entities.Assets.Entities
{
    public class Dollar : Asset, IAsset
    {
        public const string name = "Dollar";
        public const string id = "USD";
        public Dollar(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
