﻿using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Bitcoin : Asset
	{
		public const string name = "Bitcoin";
		public const string id = "BTC";
		public Bitcoin(decimal price, decimal amount) : base(name, id, price, amount)
		{

		}
	}
}
