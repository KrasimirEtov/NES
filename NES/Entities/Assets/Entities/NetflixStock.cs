using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Assets.Entities
{
    class NetflixStock : Asset
    {
        public const string name = "Netflix";
        public const string id = "NFLX";
        public NetflixStock(decimal price, decimal amount) : base(name, id, price, amount)
        {

        }
    }
}
