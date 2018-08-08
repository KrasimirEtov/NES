using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using System;
using NES.Entities.Assets;
using System.Linq;

namespace NES.Core.Engine
{
	public class AssetFactory : IFactory
	{
        private readonly static IFactory instance = new AssetFactory();

        private AssetFactory()
		{
		}

        public static IFactory Instance { get; } = instance;

        public IAsset CreateAsset(string type, decimal price, decimal amount)
		{
            type = type.First().ToString().ToUpper() + type.Substring(1);
            return (Asset)Activator.CreateInstance(Type.GetType($"NES.Entities.Assets.Entities.{type}"), price, amount);
		}
	}
}
