using Autofac;
using NES.Core.Commands;
using System.Reflection;

namespace NES
{
	public class Startup
	{
		static void Main(string[] args)
		{
			var builder = new ContainerBuilder();
			builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
			var container = builder.Build();
			var engine = container.Resolve<IEngine>();
			engine.Start();
		}
	}
}