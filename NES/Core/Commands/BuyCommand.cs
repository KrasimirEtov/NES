﻿using NES.Core.Commands.Contracts;
using NES.Entities.Broker.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NES.Core.Commands
{
    public class BuyCommand : ICommand
    {
		private string commandName;
		private int amount;

		private IBroker Broker { get; }

		public string CommandName
		{
			get => commandName;
			set
			{
				if (value.All(char.IsDigit)) throw new Exception("Asset name cannot contain only letters!");
				if (value == null) throw new ArgumentNullException("Asset name cannot be null!");
				if (value.Length < 1 || value.Length > 50) throw new Exception("Asset name length cannot be less than 1 or more than 50 characters!");
				commandName = value;
			}
		}

		public int Amount
		{
			get => amount;
			set
			{
				if (value < 1) throw new Exception("You cannot buy negative amount of assets!");
				amount = value;
			}
		}

		public BuyCommand(IBroker broker)
        {
            Broker = broker;
		}

        public string Execute(IList<string> input)
        {
			if (input.Count != 2) throw new Exception("Invalid buy command arguments!");
			CommandName = input[0];
			if (int.TryParse(input[1], out var tempAmount))
			{
				this.Amount = tempAmount;
			}
			else
			{
				throw new Exception("Incorrent input for amount!");
			}

			return Broker.Buy(this.CommandName, this.Amount);
        }
    }
}
