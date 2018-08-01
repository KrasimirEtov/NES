using System;
using System.Collections.Generic;
using System.Text;
using NES.Core.Commands;
using NES.Core.Commands.Contracts;
using NES.Entities.Assets;
using NES.Entities.Assets.Contracts;

namespace NES.Core.Commands
{
    public class CommandParser
    {
        public void ParseCommand(Command command)
        {
            switch (command.Action)
            {
                case "BuyBTC":
                    command.Amount
                    this.engine.BuyBTC(amount);
                    break;
                case "BuyETH": break;
                case "BuyGLD": break;
                case "BuySLR": break;
                case "BuyUSD": break;
                case "BuyEUR": break;
                case "Register": break;
                case "Login": break;
                case "EndDay": break;
                case "Exit": break;
            }
        }
    }
}
