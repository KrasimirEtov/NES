using NES.Core.Commands;
using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
using NES.Core.Providers;
using NES.Entities.Assets.Contracts;
using NES.Entities.Broker;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NES.Core.Engine
{
	public class Engine
	{
        private const string exitCommand = "exit";
		private static readonly Engine SingleInstance = new Engine();

		private readonly IUser user;
		private readonly IBroker broker;
        private IOConsole consoleMenager;

		private Engine()
		{
			this.broker = new Broker();
            this.consoleMenager = new IOConsole();
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
            while ((input = this.consoleMenager.ReadLine()) != exitCommand)
            {
                try
                {
                    command = Command.Parse(input);
                    ProcessCommand.Process(command, this.user, this.broker);
                }
                catch (Exception ex)
                {
                    this.consoleMenager.WriteLine(ex.Message);
                }
            }
        }



	}

}
