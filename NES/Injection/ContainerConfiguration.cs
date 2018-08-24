using Autofac;
using NES.Core.Commands;
using NES.Core.Engine;
using NES.Core.Engine.Contracts;
using NES.Entities.Broker;
using NES.Entities.Broker.Contracts;
using NES.Entities.Marketplace;
using NES.Entities.Marketplace.Contracts;
using NES.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Injection
{
    public static class ContainerConfiguration
    {
        public static IContainer Load(ContainerBuilder builder)
        {
            RegisterComponents(builder);

            IContainer container = builder.Build();
            return container;
        }

        private static void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            builder.RegisterType<Market>().As<IMarket>().SingleInstance();
            builder.RegisterType<Broker>().As<IBroker>();

            builder.RegisterType<UserHandler>().As<UserHandler>();
            builder.RegisterType<AssetFactory>().As<IAssetFactory>().SingleInstance();
            builder.RegisterType<UserFactory>().As<IUserFactory>().SingleInstance();
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
            //will register commands here
        }
    }
}
