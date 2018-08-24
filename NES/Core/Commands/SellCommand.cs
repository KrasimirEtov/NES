using NES.Core.Commands.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Commands
{
    public class SellCommand : ICommands
    {
        public IBroker Broker { get; }

        public SellCommand(IBroker broker)
        {
            this.Broker = broker;
        }

        public string Execute(IList<string> input, IUser user)
        {
            string commandName = input[0];
            int amount = int.Parse(input[1]);

            string result = this.Broker.Sell(commandName, amount, user);

            return result;
        }
    }
}
