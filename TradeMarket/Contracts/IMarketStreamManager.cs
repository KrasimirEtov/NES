using System;
using System.Collections.Generic;
using System.Text;

namespace TradeMarket.Contracts
{
	public interface IMarketStreamManager
	{
		IEnumerable<string> ReadLine(string fileName);
		void WriteLine(string message, string fileName);
		bool CheckIfFileExists(string fileName);
	}
}
