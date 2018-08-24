using NES.Core.Commands.Contracts;
using NES.Core.Providers;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Commands
{
    public class LogoutCommand : ICommands
    {
        private UserHandler UserHandler { get; }

        public LogoutCommand(UserHandler userHandler)
        {
            this.UserHandler = userHandler;
        }

        public string Execute(IList<string> input, IUser user)
        {
            this.UserHandler.SaveWallet(user.Wallet, user.Name);
            Engine.Engine.SetUser(null);
            Printer.InitialInstructions();
            return "You logged out succesfully!";
        }
    }
}
