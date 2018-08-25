using Autofac;
using NES.Core.Commands;
using NES.Core.Commands.Contracts;
using NES.Core.Engine;
using NES.Core.Engine.Contracts;
using NES.Entities.Broker;
using NES.Entities.Broker.Contracts;
using NES.Entities.Marketplace;
using NES.Entities.Marketplace.Contracts;
using NES.Entities.Users;
using System;
using System.Linq;
using System.Reflection;

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
            builder.RegisterType<NESEngine>().As<IEngine>().SingleInstance();
            builder.RegisterType<Market>().As<IMarket>().SingleInstance();
			builder.RegisterType<Broker>().As<IBroker>();

			builder.RegisterType<UserHandler>().As<UserHandler>();
            builder.RegisterType<AssetFactory>().As<IAssetFactory>().SingleInstance();
            builder.RegisterType<UserFactory>().As<IUserFactory>().SingleInstance();
            builder.RegisterType<ProcessCommand>().As<IProcessCommand>();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
			builder.RegisterType<LoginCommand>().Named<ICommand>("login");
			builder.RegisterType<RegisterCommand>().Named<ICommand>("register");
			builder.RegisterType<BuyCommand>().Named<ICommand>("buy");
			builder.RegisterType<SellCommand>().Named<ICommand>("sell");
			builder.RegisterType<EnddayCommand>().Named<ICommand>("endday");
			builder.RegisterType<LogoutCommand>().Named<ICommand>("logout");
			builder.RegisterType<PrintWalletCommand>().Named<ICommand>("printwallet");

			// reflection instead of magic strings

			//var currentAssembly = Assembly.GetExecutingAssembly();
			//var commandTypes = currentAssembly.DefinedTypes
			//	.Where(x => x.ImplementedInterfaces.Contains(typeof(ICommand)))
			//	.ToList();

			//foreach (var currCommandType in commandTypes)
			//{
			//	builder.RegisterType(currCommandType.AsType()).Named<ICommand>(currCommandType.Name.ToLower().
			//		Substring(0, currCommandType.Name.Length - 7));
			//}
		}
    }
}
