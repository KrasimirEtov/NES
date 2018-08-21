using System;

namespace NES.Core.Providers
{
    public class InitialCustomException : Exception
    {
		public InitialCustomException(string message) : base(message)
		{
            IOConsole.WriteLine(message);
		}
    }
}
