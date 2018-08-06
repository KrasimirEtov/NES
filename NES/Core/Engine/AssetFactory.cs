using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Users.Contracts;
using NES.Entities.Assets.Entities;
using NES.Entities.Users;
using System;
using NES.Entities.Assets;
using System.Linq;

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

		public IAsset CreateAsset(string type, decimal price, decimal amount)
		{
            type = type.First().ToString().ToUpper() + type.Substring(1);
            return (Asset)Activator.CreateInstance(Type.GetType($"NES.Entities.Assets.Entities.{type}"), price, amount);
		}
	}
}
