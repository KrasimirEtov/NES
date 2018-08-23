using NES.Core.Commands;
using NES.Core.Commands.Contracts;
using NES.Core.Providers;
using NES.Entities.Broker.Contracts;
using NES.Entities.Marketplace.Contracts;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;
using System;

namespace NES.Core.Engine
{
    public class Engine : IEngine
    {
        private const string exitCommand = "exit";
        private static IUser currentUser;

        private UserHandler Handler { get; set; }
        private IMarket MarketProp { get; set; }
        private IBroker Broker { get; }

        public Engine(UserHandler handler, IMarket market, IBroker broker)
		{
            this.Handler = handler;
            this.MarketProp = market;
            this.Broker = broker;
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
                    ProcessCommand.Process(command, currentUser, Broker, Handler);
					if (command.Action == "exit") break;
				}
				catch(InitialCustomException ice)
				{
                    IOConsole.WriteLine(ice.Message, ConsoleColor.Red);
				}
				catch (Exception ex)
				{
                    IOConsole.WriteLine(ex.Message, ConsoleColor.Red);
				}
			}
		}

        public static void SetUser(IUser user)
        {
            currentUser = user;
        }
    }
}