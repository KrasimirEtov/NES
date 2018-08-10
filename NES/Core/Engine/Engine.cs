using NES.Core.Commands;
using NES.Core.Commands.Contracts;
using NES.Core.Providers;
using NES.Entities.Broker;
using NES.Entities.Broker.Contracts;
using NES.Entities.Marketplace;
using NES.Entities.Marketplace.Contracts;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;
using System;

namespace NES.Core.Engine
{
	public class Engine : IEngine
	{
		private const string exitCommand = "exit";
        private readonly static Engine instance = new Engine();
        private IUser user;

        private UserHandler Handler { get; set; }
        private IMarket MarketProp { get; set; }
		private IBroker Broker { get; } 

        public static Engine Instance { get; } = instance;

        private Engine()
		{
            this.Handler = new UserHandler();
			this.MarketProp = Market.Instance;
            this.Broker = new Broker();
        }


		public void Start()
		{
			IOConsole.SetScreenSize();
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
					IOConsole.WriteLine("\nEnter command:\n");
					IOConsole.ChangeColor(ConsoleColor.Blue);
					command = Command.Parse(IOConsole.ReadLine());
					IOConsole.ResetColor();
                    ProcessCommand.Process(command, this.user, Broker, this.Handler);
					if (command.Action == "exit") break;
				}
				catch(InitialCustomException ice)
				{
                    IOConsole.ChangeColor(ConsoleColor.Red);
                    IOConsole.WriteLine(ice.Message);
					Console.ResetColor();
				}
				catch (Exception ex)
				{
                    IOConsole.ChangeColor(ConsoleColor.Red);
                    IOConsole.WriteLine(ex.Message);
					IOConsole.ResetColor();
				}
			}
		}

        public void SetUser(IUser user)
        {
            this.user = user;
        }
    }
}