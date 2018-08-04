using System;
using NES.Core.Commands.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;

namespace NES.Core.Commands
{
	public static class ProcessCommand
	{
		public static void Process(ICommand command, ref IUser user, IBroker broker)
		{
			if (user != null)
			{
				switch (command.Action)
				{
					case "buy":
						broker.Buy(command.Asset, command.Amount, user);
						break;
                    case "sell":
                        broker.Sell(command.Asset, command.Amount, user);
                        break;
                    case "endday":
						broker.EndDayTraiding();
						break;
					case "exit":
						break;
					case "printwallet":
						user.Wallet.PrintWallet();
						break;
					default:
						throw new ArgumentException($"{command.Action} is not a valid command.");
				}
			}
			else
			{
				switch (command.Action)
				{
					case "register":
						var reg = new Register();
						reg = null; // I'll ask for a better disposal
							break;
					case "login":
						var login = new Login(); // I'll ask for a better disposal
						user = login.CreateUser(); // user constructor should contain a wallet
						break;
					default:
						throw new ArgumentException($"{command.Action} is not a valid command.");
				}
			}
		}
	}
}