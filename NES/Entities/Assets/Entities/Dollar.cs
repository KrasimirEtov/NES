using NES.Entities.Assets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Assets
{
    public class Dollar : Asset, IAsset
    {
        public const string name = "Dollar";
        public const string id = "USD";
        public Dollar(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
