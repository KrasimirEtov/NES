using NES.Core.Commands.Contracts;
using NES.Core.Engine;
using NES.Core.Engine.Contracts;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Commands
{
	public class ExitCommand : ICommand
	{
		private UserHandler UserHandler { get; }
		private IPrinterManager PrinterManager { get; }
		private IOManager ConsoleManager { get; }

		public ExitCommand(UserHandler userHandler, IPrinterManager printerManager, IOManager consoleManager)
		{
			this.UserHandler = userHandler;
			PrinterManager = printerManager;
			ConsoleManager = consoleManager;
		}

		public string Execute(IList<string> input, IUser user)
		{
			if (input.Count != 0) throw new Exception("Invalid exit command arguments!");
			if (user == null)
			{
				ConsoleManager.WriteLine("\nGoodbye", ConsoleColor.Green);
				Environment.Exit(0);
			}
			this.UserHandler.SaveWallet(user.Wallet, user.Name);
			return "\nGoodbye";
		}
	}
}
