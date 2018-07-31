using NES.Entities.Assets;
using NES.Entities.Assets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NES
{
    class Startup
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			var dict = new Dictionary<IAsset, decimal>();
			var bitcoin = new Bitcoin(5m, 6m);
			var dollar = new Dollars();
			dict[bitcoin] = 5m;
		
			var lines = dict.Select(kvp => kvp.Key + ": " + kvp.Value);
			Console.WriteLine(String.Join(Environment.NewLine, lines));

		}
    }
}
