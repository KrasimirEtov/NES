using System;

namespace NES.Core.Providers
{
	public static class IOConsole
	{
		public static string ReadLine()
		{
			return Console.ReadLine();
		}

		public static void Write(string message)
		{
			Console.Write(message);
		}

		public static void WriteLine(string message)
		{
			Console.WriteLine(message);
		}
	}
}
