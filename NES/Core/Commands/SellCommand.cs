using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradeMarket.Contracts;

namespace NES.Core.Commands
{
    public class SellCommand : ICommand
    {
		private string commandName;
		private int amount;
        public IBroker Broker { get; }
		public IMarket Market { get; }
		public IPrinterManager PrinterManager { get; }

		public string CommandName
		{
			get => commandName;
			set
			{
				if (value.All(char.IsDigit)) throw new Exception("Asset name cannot contain only letters!");
				if (value == null) throw new Exception("Asset name cannot be null!");
				if (value.Length < 1 || value.Length > 50) throw new Exception("Asset name length cannot be less than 1 or more than 50 characters!");
				commandName = value;
			}
		}

		public int Amount
		{
			get => amount;
			set
			{
				if (value < 1) throw new Exception("You cannot sell negative amount of assets!");
				amount = value;
			}
		}

		public SellCommand(IBroker broker, IMarket market, IPrinterManager printerManager)
        {
            Broker = broker;
			Market = market;
			PrinterManager = printerManager;
		}

        public string Execute(IList<string> input, IUser user)
        {
			if (input.Count != 2) throw new Exception("Invalid sell command arguments!");
            CommandName = input[0];
			if (int.TryParse(input[1], out var tempAmount))
			{
				Amount = tempAmount;
			}
			else
			{
				throw new Exception("Incorrent input for amount!");
			}

			var result = Broker.Sell(commandName, Amount, user);
			PrinterManager.PrintMarket(user, Market);
			return result;
        }
    }
}
