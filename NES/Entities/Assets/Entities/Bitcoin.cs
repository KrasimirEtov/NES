using NES.Entities.Assets.Enums;
using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Bitcoin : Asset
	{
		public const string name = "Bitcoin";
		public Bitcoin(decimal price, decimal amount) : base(name, AssetType.CRIPTO, price, amount)
		{
		}
	}
}
