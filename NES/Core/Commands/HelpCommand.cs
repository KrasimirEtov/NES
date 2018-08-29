using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;

namespace NES.Core.Commands
{
	public class HelpCommand : ICommand
	{
		private IOManager ConsoleManager { get; }
		private IPrinterManager PrinterManager { get; }
		private IUserSession UserSession { get; }

		public HelpCommand(IOManager consoleManager, IPrinterManager printerManager)
		{
			ConsoleManager = consoleManager;
			PrinterManager = printerManager;
		}

		public string Execute(IList<string> input)
		{
			if (input.Count != 0) throw new Exception("Invalid help command arguments!");
			PrinterManager.PrintHelp();

			return "";
		}
	}
}
