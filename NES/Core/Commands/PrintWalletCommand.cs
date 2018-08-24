using NES.Core.Commands.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Commands
{
    public class PrintWalletCommand : ICommands
    {
        public string Execute(IList<string> input, IUser user)
        {
            return user.Wallet.PrintWallet();
        }
    }
}
