using NES.Core.Commands.Contracts;
using System;

namespace NES.Core.Commands
{
	public class Command : ICommand
	{
		private const char SplitCommandSymbol = ' ';

		private string action;
        private string asset;
		private decimal amount;

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

		public decimal Amount
		{
			get => amount;
			set
			{
				if (value < 0) throw new ArgumentOutOfRangeException("Amount cannot be negative!");
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
			if (chunks.Length == 1)
			{
				this.Action = chunks[0];
				return;
			}
			this.Action = chunks[0];
            this.Asset = chunks[1];
            this.Amount = decimal.Parse(chunks[2]);
		}
	}
}