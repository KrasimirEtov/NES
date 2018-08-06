using NES.Core.Commands;
using NES.Core.Commands.Contracts;
using NES.Core.Providers;
using NES.Entities.Broker;
using NES.Entities.Broker.Contracts;
using NES.Entities.Marketplace;
using NES.Entities.Marketplace.Contracts;
using NES.Entities.Users.Contracts;
using System;

namespace NES.Core.Engine
{
	public class Engine :IEngine
	{
		private const string exitCommand = "exit";
		private IUser user;

		public static Engine Instance { get; } = new Engine();
		private IMarket MarketProp { get; set; }
		private IBroker Broker { get; } = new Broker();
		private IOConsole ConsoleManager { get; } = new IOConsole();

		private Engine()
		{
			MarketProp = Market.Instance;
		}


		public void Start()
		{
           InitialInstructions();
            ReadCommand();
		}

        private void ReadCommand()
		{
			ICommand command;
			while (true)
			{
				try
				{
					command = Command.Parse(ConsoleManager.ReadLine());
					ProcessCommand.Process(command, ref this.user, Broker);
					if (command.Action == "exit") break;
				}
				catch (Exception ex)
				{
                    Console.ForegroundColor = ConsoleColor.Red;
                    ConsoleManager.WriteLine(ex.Message);
					Console.ResetColor();
				}
			}
		}

        private void InitialInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to Wall Street Simulator!\n");
			Console.ResetColor(); // use this instead of Console.ForegroundColor = ConsoleColor.Black; because it's showing empty input
			Console.WriteLine("If you already have an account, please use command 'login'.");
            Console.WriteLine("If you don't have an account, please create one using command 'register'.\n");
        }
    }
}