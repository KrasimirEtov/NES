using Autofac;
using NES.Core.Commands;
using NES.Core.Commands.Contracts;
using NES.Core.Engine;
using NES.Core.Engine.Contracts;
using NES.Entities.Broker;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users;
using TradeMarket;
using TradeMarket.Contracts;

namespace NES.Injection
{
    public static class ContainerConfiguration
    {
        public static IContainer Load(ContainerBuilder builder)
        {
            RegisterComponents(builder);
            RegisterCommands(builder);

            IContainer container = builder.Build();
            return container;
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
            builder.RegisterType<LoginCommand>().Named<ICommands>("login");
            builder.RegisterType<RegisterCommand>().Named<ICommands>("register");
            builder.RegisterType<BuyCommand>().Named<ICommands>("buy");
            builder.RegisterType<SellCommand>().Named<ICommands>("sell");
            builder.RegisterType<EnddayCommand>().Named<ICommands>("endday");
            builder.RegisterType<LogoutCommand>().Named<ICommands>("logout");
            builder.RegisterType<PrintWalletCommand>().Named<ICommands>("printwallet");
        }
    }
}
