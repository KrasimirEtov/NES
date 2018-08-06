using NES.Entities.Assets.Enums;
using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Silver : Asset
	{
		public const string name = "Silver";
		public Silver(decimal price, decimal amount) : base(name, AssetType.METAL, price, amount)
		{

		}
	}
}
