using Autofac;
using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;

namespace NES.Core.Engine
{
    public class CommandFactory : ICommandFactory
    {
        private IComponentContext autofacContext;

        public CommandFactory(IComponentContext autofacContext)
        {
            this.autofacContext = autofacContext;
        }


        public ICommand CreateCommand(string commandName)
        {
            return this.autofacContext.ResolveNamed<ICommand>(commandName);
        }
    }
}
