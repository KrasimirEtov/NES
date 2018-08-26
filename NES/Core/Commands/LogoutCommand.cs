﻿using NES.Core.Commands.Contracts;
using NES.Core.Engine;
using NES.Core.Engine.Contracts;
using NES.Core.Providers;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Commands
{
	public class LogoutCommand : ICommand
	{
		private UserHandler UserHandler { get; }
		private IPrinterManager PrinterManager { get; }

		public LogoutCommand(UserHandler userHandler, IPrinterManager printerManager)
		{
			this.UserHandler = userHandler;
			PrinterManager = printerManager;
		}

		public string Execute(IList<string> input, IUser user)
		{
			if (input.Count != 0) throw new Exception("Invalid logout command arguments!");
			this.UserHandler.SaveWallet(user.Wallet, user.Name);
			NESEngine.SetUser(null);
			PrinterManager.InitialInstructions();
			return "You logged out succesfully!";
		}
	}
}
