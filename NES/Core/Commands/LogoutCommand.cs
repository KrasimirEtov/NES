using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Commands
{
	public class LogoutCommand : ICommand
	{
		public IStreamManager StreamManager { get; }
		private IPrinterManager PrinterManager { get; }
		private IUserSession UserSession { get; }

		public LogoutCommand(IStreamManager streamManager, IPrinterManager printerManager, IUserSession userSession)
		{
			StreamManager = streamManager;
			PrinterManager = printerManager;
			UserSession = userSession;
		}

		public string Execute(IList<string> input)
		{
			if (input.Count != 0) throw new Exception("Invalid logout command arguments!");
			StreamManager.SaveWallet(UserSession.User.Wallet, UserSession.User.Name);
			UserSession.Logout();
			PrinterManager.InitialInstructions();

			return "You logged out succesfully!";
		}
	}
}
