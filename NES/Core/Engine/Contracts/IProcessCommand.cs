using System.Collections.Generic;

namespace NES.Core.Engine.Contracts
{
    public interface IProcessCommand
    {
        string ProcessCurrentCommand(IList<string> parameters);
    }
}
