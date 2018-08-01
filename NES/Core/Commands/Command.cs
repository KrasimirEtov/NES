using NES.Core.Commands.Contracts;
using NES.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Commands
{
    public class Command :ICommand
    {
        private const char SplitCommandSymbol = ' ';

        private string action;

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
        
        public decimal Amount { get; private set; }

        public static ICommand Parse(string input)
        {
            return new Command(input);
        }

        private void TranslateInput(string input)
        {
            string[] chunks = input.Split(SplitCommandSymbol);
			if (chunks.Length == 1)
			{
				/* this is to test the register 
				if (chunks[0].equals("register"))
				{
					console.writeline("type: 'username' 'password' 'cash'");
					string[] inputdata = console.readline().split(' ');
					var register = new register(inputdata[0]);
					register.writer.writeline(register.registeruser(inputdata[0], inputdata[1], decimal.parse(inputdata[2])));
					register.writer.close();
				}
				*/
				this.Action = chunks[0];
				return;
			}

            this.Action = chunks[0];
            this.Amount = decimal.Parse(chunks[1]);
        }
    }
}
