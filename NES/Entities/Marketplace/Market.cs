using NES.Entities.Assets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Marketplace
{
    public class Market
    {
		private readonly Dictionary<string, ICollection<IAsset>> categories;
    }
}
