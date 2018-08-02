namespace NES.Entities.Assets.Entities
{
	class Silver : Asset
	{
		public const string name = "Silver";
		public const string id = "SLV";
		public Silver(decimal price, decimal amount) : base(name, id, price, amount)
		{

		}
	}
}
