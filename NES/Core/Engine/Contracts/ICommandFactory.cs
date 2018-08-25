using NES.Core.Commands.Contracts;

namespace NES.Core.Engine.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
