using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Engine.Contracts
{
	public interface IConsoleManager
	{
		string ReadLine();
		void Write(string message, ConsoleColor color = ConsoleColor.White);
		void WriteLine(string message = "", ConsoleColor color = ConsoleColor.White);
		void ChangeColor(ConsoleColor console);
		void ResetColor();
		void Clear();
		void SetScreenSize();
		void WriteAligned(string spacing, string value);
	}
}
