using System;
using NES.Core.Commands.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;

namespace NES.Core.Commands
{
	public static class ProcessCommand
	{
		public static void Process(ICommand command, IUser user, IBroker broker)
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
						Console.WriteLine("Enter 'username' 'password' 'cash' seperated by whitespace");
						var input = Console.ReadLine().Split(' ');
						var reg = new Register(input[0], input[1], decimal.Parse(input[2]));
						break;
					case "login":
						user = new User("krasi", 20, 20000);
						break;
					default:
						throw new ArgumentException($"{command.Action} is not a valid command.");
				}
			}
		}
	}
}