using NES.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Engine.Contracts
{
    public interface ICommandFactory
    {
        ICommands CreateCommand(string commandName);
    }
}
