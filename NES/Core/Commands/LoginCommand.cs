﻿using NES.Core.Commands.Contracts;
using NES.Core.Engine;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Commands
{
    public class LoginCommand : ICommand
    {
        private UserHandler Handler { get; }
        private IBroker Broker { get; }

        public LoginCommand(UserHandler handler, IBroker broker)
        {
            this.Handler = handler;
            this.Broker = broker;
        }

        public string Execute(IList<string> input, IUser user)
        {
            user = this.Handler.LoginUser(input, user);
            NESEngine.SetUser(user);
            this.Broker.EndDayTraiding(user);

            return "Welcome";
        }
    }
}