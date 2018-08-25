using Autofac;
using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

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
