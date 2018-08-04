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
	public class Engine
	{
		private const string exitCommand = "exit";
		private static readonly Engine SingleInstance = new Engine();

		private IUser user;
		private readonly IBroker broker;
		private readonly IOConsole consoleManager;
		private IMarket market;

		private Engine()
		{
			this.broker = new Broker();
			this.consoleManager = new IOConsole();
			this.market = Market.Instance;
		}

		public static Engine Instance
		{
			get => SingleInstance;
		}

		public void Start()
		{
			ReadCommand();
		}

		private void ReadCommand()
		{
			ICommand command;
			string input;
			while ((input = this.consoleManager.ReadLine()) != exitCommand)
			{
				try
				{
					command = Command.Parse(input);
					ProcessCommand.Process(command, ref this.user, this.broker);
				}
				catch (Exception ex)
				{
					this.consoleManager.WriteLine(ex.Message);
				}
			}
		}
	}
}