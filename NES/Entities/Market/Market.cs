using NES.Entities.Assets.Contracts;
using NES.Entities.Category.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Market
{
    public class Market
    {
		private readonly Dictionary<string, ICollection<IAsset>> categories;
    }
}
