using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
using NES.Entities.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NES.Core.Engine
{
	public class Engine
	{
		private static readonly Engine SingleInstance = new Engine();

		// private readonly IMarket market;
		// private readonly IUser user;
		private readonly IFactory factory;

		private Engine()
		{
			//this.market = Market.Instance;
			this.factory = AssetFactory.Instance;
		}

		public static Engine Instance
		{
			get => SingleInstance;
		}

		/* we need to change how the process command works - 
				  if we want to register we need to use list of parameters like workshop 2 */
		//private void ProcessSingleCommand(ICommand command)
		//{
		//	switch (command.Action)
		//	{
		//		case "register":
		//			Console.WriteLine("Type: 'username' 'password' 'cash'");
		//			string[] input = Console.ReadLine().Split(' ');
		//			var register = new Register();
		//			if (register.CheckIfUserExists(input[0])) throw new ArgumentException("User already exist in the database :D");
		//			register.Writer.WriteLine(register.RegisterUser(input[0], input[1], decimal.Parse(input[3])));
		//			break;
		//	}
		//}
	}

}
