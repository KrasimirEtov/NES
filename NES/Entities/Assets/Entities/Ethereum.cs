namespace NES.Entities.Assets.Entities
{
    public class Ethereum : Asset
    {
        public const string name = "Ethereum";
        public const string id = "ETH";
        public Ethereum(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
