using NES.Core.Commands;
using NES.Core.Engine.Contracts;
using NES.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NES.Core.Engine
{
    public class NESEngine : IEngine
    {
        private const string exitCommand = "exit";
        private IProcessCommand CommandProcessor { get; }
		private IOManager ConsoleManager { get; }
		private IPrinterManager PrinterManager { get; }

		public NESEngine(IProcessCommand commandProcessor, IOManager consoleManager, IPrinterManager printerManager)
		{
			CommandProcessor = commandProcessor;
			ConsoleManager = consoleManager;
			PrinterManager = printerManager;
		}

		public void Start()
		{
			ConsoleManager.SetScreenSize();
			PrinterManager.InitialInstructions();
			ReadCommand();
		}

		private void ReadCommand()
		{
			while (true)
			{
				try
				{
					ConsoleManager.WriteLine("\nEnter command:\n");
					ConsoleManager.ChangeColor(ConsoleColor.Blue);

					IList<string> parameters = ConsoleManager.ReadLine().Split().ToList();

					string result = CommandProcessor.ProcessCurrentCommand(parameters);
					ConsoleManager.WriteLine(result, ConsoleColor.Green);
					ConsoleManager.ResetColor();
					if (parameters[0] == "exit") Environment.Exit(0);
				}
				catch (InitialCustomException ice)
				{
					ConsoleManager.WriteLine(ice.Message, ConsoleColor.Red);
				}
				catch (Exception ex)
				{
					ConsoleManager.WriteLine(ex.Message, ConsoleColor.Red);
				}
			}
		}
    }
}