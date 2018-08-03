namespace NES.Entities.Assets.Entities
{
    class GoogleStock : Asset
    {
        public const string name = "GoogleStock";
        public const string id = "GOOGL";
        public GoogleStock(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
