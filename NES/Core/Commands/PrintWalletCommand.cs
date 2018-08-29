using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;

namespace NES.Core.Commands
{
	public class PrintWalletCommand : ICommand
	{
		private IOManager ConsoleManager { get; }
		private IPrinterManager PrinterManager { get; }
		private IUserSession UserSession { get; }

		public PrintWalletCommand(IOManager consoleManager, IPrinterManager printerManager, IUserSession userSession)
		{
			ConsoleManager = consoleManager;
			PrinterManager = printerManager;
			UserSession = userSession;
		}

		public string Execute(IList<string> input)
		{
			if (input.Count != 0) throw new Exception("Invalid printwallet command arguments!");
			ConsoleManager.Write(PrinterManager.PrintWallet(UserSession.User));
			return string.Empty;
		}
	}
}
