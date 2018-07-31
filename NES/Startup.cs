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
			// this can be in a class that contains print methods?
			//user testing - we need an engine to process the commands
			Console.WriteLine("Welcome!");
			Console.WriteLine("Type: 'register' to register if you are a new user");
			Console.WriteLine("Type: 'login' if you already have an account");
			var registerUser = Command.Parse("register");

			/*
            ICommand command = Command.Parse("exit");
            Console.WriteLine(command.Action);
            Console.WriteLine(command.ID);
            Console.WriteLine(command.Amount);

            var dict = new Dictionary<IAsset, decimal>();
            var bitcoin = new Bitcoin(5m, 6m);
            var dollar = new Dollar();
            dict[bitcoin] = 5m;

            var lines = dict.Select(kvp => kvp.Key + ": " + kvp.Value);
			Console.WriteLine(String.Join(Environment.NewLine, lines));
			*/
        }
    }
}
