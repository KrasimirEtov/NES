using NES.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NES.Core.Commands
{
    public class Command : ICommand
    {
        private const char SplitCommandSymbol = ' ';

        private string action;
        private string asset;
        private decimal amount;
        private List<string> parameters;

        private Command(string input)
        {
            this.TranslateInput(input);
        }

        public string Action
        {
            get => this.action;
            private set
            {
                this.action = value ?? throw new ArgumentNullException("Command cannot be null!");
            }
        }

        public string Asset
        {
            get => this.asset;
            private set
            {
                this.asset = value ?? throw new ArgumentNullException("Command cannot be null!");
            }
        }

        public List<string> Parameters
        {
            get => new List<string>(this.parameters);
            private set
            {
                this.parameters = value;
            }
        }

        public decimal Amount
        {
            get => amount;
            set
            {
                if (value <= 0) throw new Exception("Amount cannot be negative or equal to zero!");
                amount = value;
            }
        }

        public static ICommand Parse(string input)
        {
            return new Command(input);
        }

        private void TranslateInput(string input)
        {
            string[] chunks = input.ToLower().Split(SplitCommandSymbol);
            this.Parameters = chunks.Skip(1).ToList();
            this.Action = chunks[0];

            if (chunks.Length == 1) //exit
            {
                return;
            }
            if (this.Action == "login" || this.Action == "register")
            {
                return;
            }            

			if (chunks.Length != 3) throw new Exception("Invalid command format");

            this.Action = chunks[0];
            this.Asset = chunks[1];
			if (decimal.TryParse(chunks[2], out var amount))
			{
				this.Amount = amount;
			}
			else
			{
				throw new Exception("Incorrent input for amount!");
			}
		}
	}
}