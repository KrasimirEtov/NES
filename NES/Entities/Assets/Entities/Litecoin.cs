﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Assets.Entities
{
    class Litecoin : Asset
    {
        public const string name = "Litecoin";
        public const string id = "LTC";
        public Litecoin(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
