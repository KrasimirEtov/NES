using NES.Entities.Assets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Assets.Entities
{
    class Ethereum : Asset
    {
        public const string name = "Ethereum";
        public const string id = "ETH";
        public Ethereum(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
