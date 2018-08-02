using NES.Core.Providers.Contracts;
using System;

namespace NES.Core.Providers
{
	public class IOConsole : IReader, IWriter
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}

		public void Write(string message)
		{
			Console.Write(message);
		}

		public void WriteLine(string message)
		{
			Console.WriteLine(message);
		}
	}
}
