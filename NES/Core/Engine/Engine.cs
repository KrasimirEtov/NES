﻿using NES.Core.Commands;
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

		private readonly IUser user;
		private readonly IBroker broker;
		private IOConsole consoleManager;
		private IMarket market;

		private Engine()
		{
			this.broker = new Broker();
			this.consoleManager = new IOConsole();
			this.user = new User("krasi", 20, 20000);
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
					ProcessCommand.Process(command, this.user, this.broker);
				}
				catch (Exception ex)
				{
					this.consoleManager.WriteLine(ex.Message);
				}
			}
		}
	}
}