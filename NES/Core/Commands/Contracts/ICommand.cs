using System.Collections.Generic;

namespace NES.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> input);
    }
}
