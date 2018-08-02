﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Assets.Entities
{
    class Platinum : Asset
    {
        public const string name = "Platinum";
        public const string id = "PT";
        public Platinum(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}