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
			Printer.SetScreenSize();
			Printer.InitialInstructions();
            ReadCommand();
		}

        private void ReadCommand()
		{
			ICommand command;
			while (true)
			{
				try
				{
					ConsoleManager.WriteLine("\nEnter command:\n");
					command = Command.Parse(ConsoleManager.ReadLine());
                    ProcessCommand.Process(command, ref this.user, Broker);
					if (command.Action == "exit") break;
				}
				catch(InitialCustomException ice)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					ConsoleManager.WriteLine(ice.Message);
					Console.ResetColor();
				}
				catch (Exception ex)
				{
                    Console.ForegroundColor = ConsoleColor.Red;
                    ConsoleManager.WriteLine(ex.Message);
					Console.ResetColor();
				}
			}
		}
    }
}