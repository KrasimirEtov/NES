using System;
using System.Collections.Generic;
using System.Text;
using NES.Core.Commands;
using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
using NES.Entities.Assets;
using NES.Entities.Assets.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users.Contracts;

namespace NES.Core.Commands
{
    public static class ProcessCommand
    {
        public static void Process(ICommand command, IUser user, IBroker broker)
        {
            switch (command.Action)
            {
                case "BuyBTC":
                    broker.BuyBTC(command.Amount, user);
                    break;
                case "BuyETH":
                    break;
                case "BuyGLD":
                    break;
                case "BuySLR":
                    break;
                case "BuyUSD":
                    break;
                case "BuyEUR":
                    break;
                case "Register":
                    break;
                case "Login":
                    break;
                case "EndDay":
                    break;
                case "Exit":
                    break;
                default:
                    throw new ArgumentException($"{command.Action} is not a valid command.");
            }
        }
    }
}
