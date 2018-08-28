using NES.Core.Commands.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;
using System.Collections.Generic;

namespace NES.Core.Commands
{
    public class LoginCommand : ICommand
    {
        private UserHandler Handler { get; }
        private IBroker Broker { get; }
		private IUserSession UserSession { get; }

		public LoginCommand(UserHandler handler, IBroker broker, IUserSession userSession)
        {
            this.Handler = handler;
            this.Broker = broker;
			UserSession = userSession;
		}

        public string Execute(IList<string> input)
        {
			UserSession.User = this.Handler.LoginUser(input);
            this.Broker.EndDayTraiding();

            return "Welcome";
        }
    }
}
