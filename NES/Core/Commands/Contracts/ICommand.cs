using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> input, IUser user);
    }
}
