using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Commands
{
	public class PrintWalletCommand : ICommand
	{
		private IOManager ConsoleManager { get; }
		public PrintWalletCommand(IOManager consoleManager)
		{
			ConsoleManager = consoleManager;
		}

		public string Execute(IList<string> input, IUser user)
		{
			if (input.Count != 0) throw new Exception("Invalid printwallet command arguments!");
			ConsoleManager.Write(user.Wallet.PrintWallet());
			return string.Empty;
		}
	}
}
