using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Action { get; }
        decimal Amount { get; }
    }
}
