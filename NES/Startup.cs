using NES.Core.Commands;
using NES.Core.Commands.Contracts;
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
            ICommand command = Command.Parse("buybtc 100");
            Console.WriteLine(command.Action);
            Console.WriteLine(command.Amount);

            var dict = new Dictionary<IAsset, decimal>();
            var bitcoin = new Bitcoin(5m, 6m);
            var dollar = new Dollar();
            dict[bitcoin] = 5m;

            var lines = dict.Select(kvp => kvp.Key + ": " + kvp.Value);
            Console.WriteLine(String.Join(Environment.NewLine, lines));

        }
    }
}
