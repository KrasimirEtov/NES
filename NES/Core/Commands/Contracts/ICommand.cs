using System.Collections.Generic;

namespace NES.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Action { get; }
        string Asset { get; }
        decimal Amount { get; }
        List<string> Parameters { get; }
    }
}
