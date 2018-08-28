using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;

namespace NES.Core.Commands
{
	public class ExitCommand : ICommand
	{
		private IStreamManager StreamManager { get; }
		private IOManager ConsoleManager { get; }
		private IUserSession UserSession { get; }

		public ExitCommand(IStreamManager streamManager, IOManager consoleManager, IUserSession userSession)
		{
			StreamManager = streamManager;
			ConsoleManager = consoleManager;
			UserSession = userSession;
		}

		public string Execute(IList<string> input)
		{
			if (input.Count != 0) throw new Exception("Invalid exit command arguments!");
			if (UserSession.User == null)
			{
				ConsoleManager.WriteLine("\nGoodbye", ConsoleColor.Green);
				Environment.Exit(0);
			}
			StreamManager.SaveWallet(UserSession.User.Wallet, UserSession.User.Name);

			return "\nGoodbye";
		}
	}
}
