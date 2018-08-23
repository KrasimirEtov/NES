using Autofac;
using NES.Core.Commands;
using NES.Core.Engine;
using NES.Injection;

namespace NES
{
	public class Startup
	{
		static void Main(string[] args)
		{
            ContainerBuilder builder = new ContainerBuilder();
            IContainer container = ContainerConfiguration.Load(builder);

            IEngine engine = container.Resolve<IEngine>();
            engine.Start();
		}
	}
}