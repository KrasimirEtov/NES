using NES.Entities.Assets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Assets.Entities
{
    class Euro : Asset, IAsset
    {
        public const string name = "Euro";
        public const string id = "EUR";
        public Euro(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
