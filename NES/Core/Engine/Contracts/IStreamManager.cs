using NES.Entities.Wallets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Engine.Contracts
{
	public interface IStreamManager
	{
		IEnumerable<string> ReadLine(string fileName);
		void WriteLine(string message, string fileName);
		void WriteLineAppend(string message, string fileName);
		void BinaryWrite(IWallet wallet, string fileName);
		IWallet BinaryRead(string fileName);
		string ReadAllText(string fileName);
		bool CheckIfFileExists(string fileName);
	}
}
