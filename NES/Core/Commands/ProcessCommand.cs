using System;
using NES.Core.Commands.Contracts;
using NES.Core.Providers;
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
						broker.EndDayTraiding(user);
                        break;
					case "exit":
						IOStream.BinaryWrite(user.Wallet, $"{user.Name}Wallet");
						Console.WriteLine("Goodbye!");
						break;
					case "printwallet":
						user.Wallet.PrintWallet();
						break;
					case "logout":
						IOStream.BinaryWrite(user.Wallet, $"{user.Name}Wallet");
						user = null;
						Console.WriteLine("Successfully logged out!");
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
						reg = null;
							break;
					case "login":
						var login = new Login(); 
						user = login.CreateUser();
						login = null;
                        broker.EndDayTraiding(user);
						break;
					case "exit":
						Console.WriteLine("Goodbye!");
						break;
					default:
						throw new ArgumentException($"{command.Action} is not a valid command.");
				}
			}
		}
	}
}