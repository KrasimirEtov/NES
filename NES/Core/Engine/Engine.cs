using NES.Core.Commands;
using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
using NES.Core.Providers;
using NES.Entities.Users;
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

		// private readonly IMarket market;
		// private readonly IUser user;
		private readonly IFactory factory;
        private IOConsole consoleMenager;

		private Engine()
		{
			//this.market = Market.Instance;
			this.factory = AssetFactory.Instance;
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
                command = Command.Parse(input);
            }
        }

	}

}
