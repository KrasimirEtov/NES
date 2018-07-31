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
        IAsset CreateRipple(decimal price, decimal amount);

        IAsset CreateDollar(decimal price, decimal amount);
        IAsset CreateEuro(decimal price, decimal amount);
        IAsset CreatePound(decimal price, decimal amount);

        IAsset CreateGold(decimal price, decimal amount);
        IAsset CreatePetrol(decimal price, decimal amount);
        IAsset CreateSilver(decimal price, decimal amount);

        IAsset CreateApple(decimal price, decimal amount);
        IAsset CreateFacebook(decimal price, decimal amount);
        IAsset CreateGoogle(decimal price, decimal amount);

        IUser CreateUser(string name, int age);
    }
}
