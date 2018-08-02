using NES.Entities.Assets.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Engine.Contracts
{
    public interface IFactory
    {
        IAsset CreateBitcoin(decimal price, decimal amount);
        IAsset CreateEtherium(decimal price, decimal amount);

        IAsset CreateGold(decimal price, decimal amount);
        IAsset CreateSilver(decimal price, decimal amount);

        IAsset CreateFacebookStock(decimal price, decimal amount);
        IAsset CreateGoogleStock(decimal price, decimal amount);
    }
}
