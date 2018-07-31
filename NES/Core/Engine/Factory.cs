using System;
using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Users.Contracts;
using System.Collections.Generic;
using System.Text;
using NES.Entities.Assets;

namespace NES.Core.Engine
{
	public class Factory : IFactory
    {
        private static IFactory instanceHolder = new Factory();

        private Factory()
        {

        }

        public static IFactory Instance
        {
            get
            {
                return instanceHolder;
            }
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
            throw new NotImplementedException();
        }

        public IAsset CreateEtherium(decimal price, decimal amount)
        {
            throw new NotImplementedException();
        }

        public IAsset CreateEuro(decimal price, decimal amount)
        {
            throw new NotImplementedException();
        }

        public IAsset CreateFacebook(decimal price, decimal amount)
        {
            throw new NotImplementedException();
        }

        public IAsset CreateGold(decimal price, decimal amount)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IUser CreateUser(string name, int age)
        {
            throw new NotImplementedException();
        }
    }
}
