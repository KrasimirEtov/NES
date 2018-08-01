using System;
using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Users.Contracts;
using System.Collections.Generic;
using System.Text;
using NES.Entities.Assets.Entities;

namespace NES.Core.Engine
{
	public class AssetFactory : IFactory
    {
        private static IFactory InstanceHolder = new AssetFactory();

        private AssetFactory()
        {

        }

        public static IFactory Instance
        {
            get => InstanceHolder;
        }

        public IAsset CreateApple(decimal price, decimal amount)
        {
            throw new NotImplementedException();
        }

        public IAsset CreateBitcoin(decimal price, decimal amount)
        {
            return new Bitcoin(price, amount);
        }

        public IAsset CreateDollar(decimal price, decimal amount)
        {
            return new Dollar(price, amount);
        }

        public IAsset CreateEtherium(decimal price, decimal amount)
        {
            return new Ethereum(price, amount);
        }

        public IAsset CreateEuro(decimal price, decimal amount)
        {
            return new Euro(price, amount);
        }

        public IAsset CreateFacebook(decimal price, decimal amount)
        {
            throw new NotImplementedException();
        }

        public IAsset CreateGold(decimal price, decimal amount)
        {
            return new Gold(price, amount);
        }

        public IAsset CreateGoogle(decimal price, decimal amount)
        {
            throw new NotImplementedException();
        }

        public IAsset CreatePetrol(decimal price, decimal amount)
        {
            throw new NotImplementedException();
        }

        public IAsset CreatePound(decimal price, decimal amount)
        {
            throw new NotImplementedException();
        }

        public IAsset CreateRipple(decimal price, decimal amount)
        {
            throw new NotImplementedException();
        }

        public IAsset CreateSilver(decimal price, decimal amount)
        {
            return new Silver(price, amount);
        }
    }
}
