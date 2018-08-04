﻿using System;

namespace NES.Entities.Assets.Entities
{
	[Serializable]
	public class Platinum : Asset
    {
        public const string name = "Platinum";
        public const string id = "PT";
        public Platinum(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
