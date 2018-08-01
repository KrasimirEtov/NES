using NES.Entities.Assets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Assets
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
