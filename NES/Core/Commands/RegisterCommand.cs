using NES.Core.Commands.Contracts;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users;
using NES.Entities.Users.Contracts;
using System.Collections.Generic;

namespace NES.Core.Commands
{
    public class RegisterCommand : ICommand
    {
        private UserHandler UserHandler { get; }
        private IBroker Broker { get; }
		private IUserSession UserSession { get; }

		public RegisterCommand(UserHandler userHandler, IBroker broker, IUserSession userSession)
        {
            this.UserHandler = userHandler;
            this.Broker = broker;
			UserSession = userSession;
		}

        public string Execute(IList<string> input)
        {
			UserSession.User = UserHandler.RegisteUser(input);
            this.Broker.EndDayTraiding();

            return "Welcome";
        }
    }
}
