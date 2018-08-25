﻿using NES.Core.Commands;
using NES.Core.Engine.Contracts;
using NES.Core.Providers;
<<<<<<< HEAD

=======
>>>>>>> 348c98f615e8fa70754f0d96f17572b0691ffe18
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NES.Core.Engine
{
    public class NESEngine : IEngine
    {
        private const string exitCommand = "exit";
        private static IUser currentUser;
        private IProcessCommand CommandProcessor { get; }

        public NESEngine(IProcessCommand commandProcessor)
		{
            this.CommandProcessor = commandProcessor;
        }


		public void Start()
		{
			IOConsole.SetScreenSize();
			Printer.InitialInstructions();
            ReadCommand();
		}

        private void ReadCommand()
		{
			while (true)
			{
				try
				{
					IOConsole.WriteLine("\nEnter command:\n");
					IOConsole.ChangeColor(ConsoleColor.Blue);

                    IList<string> parameters = IOConsole.ReadLine().Split().ToList();

                    if (parameters[0] == "exit")
                    {
                        IOConsole.WriteLine("GoodBye!", ConsoleColor.Green);
                        Environment.Exit(0);
                    }

                    string result = CommandProcessor.ProcessCurrentCommand(parameters, currentUser);
                    IOConsole.WriteLine(result, ConsoleColor.Green);
                    IOConsole.ResetColor();
                }
				catch(InitialCustomException ice)
				{
                    IOConsole.WriteLine(ice.Message, ConsoleColor.Red);
				}
				catch (Exception ex)
				{
                    IOConsole.WriteLine(ex.Message, ConsoleColor.Red);
				}
			}
		}

        public static void SetUser(IUser user)
        {
            currentUser = user;
        }
    }
}