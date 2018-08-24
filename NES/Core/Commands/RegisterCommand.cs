using NES.Core.Commands.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Commands
{
    public class RegisterCommand : ICommands
    {
        private UserHandler UserHandler { get; }
        private IBroker Broker { get; }

        public RegisterCommand(UserHandler userHandler, IBroker broker)
        {
            this.UserHandler = userHandler;
            this.Broker = broker;
        }

        public string Execute(IList<string> input, IUser user)
        {
            user = this.UserHandler.RegisteUser(input);
            Engine.Engine.SetUser(user);
            this.Broker.EndDayTraiding(user);

            return "Welcome";
        }
    }
}
