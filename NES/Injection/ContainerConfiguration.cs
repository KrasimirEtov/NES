using Autofac;
using NES.Core.Commands;
using NES.Core.Commands.Contracts;
using NES.Core.Engine;
using NES.Core.Engine.Contracts;
using NES.Entities.Broker;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users;
using System;
using System.Linq;
using System.Reflection;
using TradeMarket;
using TradeMarket.Contracts;

namespace NES.Injection
{
    public class ContainerConfiguration : Autofac.Module
    {
		protected override void Load(ContainerBuilder builder)
		{
			RegisterComponents(builder);
			RegisterCommands(builder);
			base.Load(builder);
		}

		private static void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsImplementedInterfaces();

            builder.RegisterType<UserHandler>().AsSelf();
            builder.RegisterType<NESEngine>().As<IEngine>().SingleInstance();
            builder.RegisterType<Market>().As<IMarket>().SingleInstance();
            builder.RegisterType<AssetFactory>().As<IAssetFactory>().SingleInstance();
            builder.RegisterType<UserFactory>().As<IUserFactory>().SingleInstance();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
			var currentAssembly = Assembly.GetExecutingAssembly();
			var commandTypes = currentAssembly.DefinedTypes
				.Where(x => x.ImplementedInterfaces.Contains(typeof(ICommand)))
				.ToList();

			foreach (var currcommandtype in commandTypes)
			{
				builder.RegisterType(currcommandtype.AsType()).Named<ICommand>(currcommandtype.Name.ToLower()
                    .Substring(0, currcommandtype.Name.Length - 7));
			}
		}
    }
}
