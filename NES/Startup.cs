using NES.Entities.Assets;
using NES.Entities.Assets.Contracts;
using System;
using System.Collections.Generic;

namespace NES
{
    class Startup
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			var dict = new Dictionary<IAsset, decimal>();
			var bitcoin = new Bitcoin();
			var dollar = new Dollars();

			//if (dict.ContainsKey(bitcoin.name))
			//{

			//}
        }
    }
}
