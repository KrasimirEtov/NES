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
                    broker.BuyETH(command.Amount, user);
                    break;
                case "BuyLTC":
                    broker.BuyLitecoin(command.Amount, user);
                    break;
                case "BuyGLD":
                    broker.BuyGold(command.Amount, user);
                    break;
                case "BuySLR":
                    broker.BuySilver(command.Amount, user);
                    break;
                case "BuyPT":
                    broker.BuyPlatinum(command.Amount, user);
                    break;
                case "BuyFB":
                    broker.BuyFacebookStock(command.Amount, user);
                    break;
                case "BuyGOOGL":
                    broker.BuyGoogleStock(command.Amount, user);
                    break;
                case "BuyNFLX":
                    broker.BuyNetflixStock(command.Amount, user);
                    break;
                case "Register":
                    break;
                case "Login":
                    break;
                case "EndDay":
                    break;
                case "Exit":
                    break;
                case "PrintWallet":
                    user.Wallet.PrintWallet();
                    break;
                default:
                    throw new ArgumentException($"{command.Action} is not a valid command.");
            }
        }
    }
}
