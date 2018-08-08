using System;
using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
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
                        Console.WriteLine("Trading day has ended!");
                        break;
					case "exit":
						IOStream.BinaryWrite(user.Wallet, $"{user.Name}Wallet");
						Console.WriteLine("\nGoodbye!");
						break;
					case "printwallet":
						user.Wallet.PrintWallet();
						break;
					case "logout":
						user.SaveWallet();
						user = null;
						Printer.InitialInstructions();
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("You logged out succesfully!");
						Console.ResetColor();
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
                        user = handler.RegisteUser(command.Parameters);
                        Engine.Engine.Instance.SetUser(user);
                        broker.EndDayTraiding(user);
                        break;
					case "login":
                        user = handler.LoginUser(command.Parameters);
                        Engine.Engine.Instance.SetUser(user);
                        broker.EndDayTraiding(user);
						break;
					case "exit":
						Console.WriteLine("\nGoodbye!");
						break;
					default:
						throw new ArgumentException($"{command.Action} is not a valid command.");
				}
			}
		}
	}
}