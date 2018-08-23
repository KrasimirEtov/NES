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
		public static void Process(ICommand command, IUser user, IBroker broker, UserHandler handler)
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
                        IOConsole.WriteLine("Trading day has ended!", ConsoleColor.DarkGray);
                        break;
					case "exit":
						IOStream.BinaryWrite(user.Wallet, $"{user.Name}Wallet");
						IOConsole.WriteLine("\nGoodbye!");
						break;
					case "printwallet":
						user.Wallet.PrintWallet();
						break;
					case "logout":
						handler.SaveWallet(user.Wallet, user.Name);
						Engine.Engine.SetUser(null);
						Printer.InitialInstructions();
						IOConsole.WriteLine("You logged out succesfully!", ConsoleColor.Green);
						break;
					default:
						throw new InitialCustomException($"{command.Action} is not a valid command.");
				}
			}
			else
			{
				switch (command.Action)
				{
					case "register":
                        user = handler.RegisteUser(command.Parameters);
                        Engine.Engine.SetUser(user);
                        broker.EndDayTraiding(user);
                        break;
					case "login":
                        user = handler.LoginUser(command.Parameters);
                        Engine.Engine.SetUser(user);
                        broker.EndDayTraiding(user);
						break;
					case "exit":
						IOConsole.WriteLine("\nGoodbye!");
						break;
					default:
						throw new InitialCustomException($"{command.Action} is not a valid command.");
				}
			}
		}
	}
}