using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Engine.Contracts
{
    public interface IProcessCommand
    {
        string ProcessCurrentCommand(IList<string> parameters, IUser user);
    }
}
