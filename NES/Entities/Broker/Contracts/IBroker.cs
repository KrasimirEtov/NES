using NES.Core.Engine.Contracts;
using NES.Entities.Marketplace.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Broker.Contracts
{
    public interface IBroker
    {
        void BuyBTC(decimal amount, IUser user);
    }
}
