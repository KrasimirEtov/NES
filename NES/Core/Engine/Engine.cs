using NES.Core.Engine.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Engine
{
    public class Engine
    {
        private static readonly Engine SingleInstance = new Engine();

        // private readonly IMarket market;
        // private readonly IUser user;
        private readonly IFactory factory;

        private Engine()
        {
            //this.market = Market.Instance;
            this.factory = AssetFactory.Instance;
        }

        public static Engine Instance
        {
            get => SingleInstance;
        }
    }
}
