using Autofac;
using NES.Core.Commands;
using System.Reflection;
using TradeMarket;

namespace NES
{
	public class Startup
	{
		static void Main(string[] args)
		{
			var builder = new ContainerBuilder();
			builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

			builder.RegisterAssemblyModules(typeof(Market));
			var container = builder.Build();
			var engine = container.Resolve<IEngine>();
			engine.Start();
		}
	}
}