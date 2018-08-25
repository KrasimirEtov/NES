using NES.Core.Commands.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Commands
{
    public class EnddayCommand : ICommand
    {
        private IBroker Broker { get; }

        public EnddayCommand(IBroker broker)
        {
            this.Broker = broker;
        }

        public string Execute(IList<string> input, IUser user)
        {
            string result = this.Broker.EndDayTraiding(user);

            return result;
        }
    }
}
