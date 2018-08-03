namespace NES.Entities.Assets.Entities
{
    class FacebookStock : Asset
    {
        public const string name = "FacebookStock";
        public const string id = "FB";
        public FacebookStock(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
