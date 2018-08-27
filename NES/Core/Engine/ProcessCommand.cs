using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
using NES.Entities.Users.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace NES.Core.Engine
{
    public class ProcessCommand : IProcessCommand
    {
        private ICommandFactory CommandFactory { get; }

        public ProcessCommand(ICommandFactory commandFactory)
        {
            this.CommandFactory = commandFactory;
        }

        public string ProcessCurrentCommand(IList<string> parameters, IUser user)
        {
            string commandName = parameters[0];
            IList<string> values = parameters.Skip(1).ToList();

            ICommand command = this.CommandFactory.CreateCommand(commandName);

			return command.Execute(values, user);
        }
    }
}
