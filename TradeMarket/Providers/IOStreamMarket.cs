using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TradeMarket.Contracts;

namespace TradeMarket.Providers
{
	public class IOStreamMarket : IMarketStreamManager
	{
		public IEnumerable<string> ReadLine(string fileName)
		{
			if (!CheckIfFileExists(fileName)) throw new Exception("File does not exist");
			using (StreamReader sr = new StreamReader($"../../../Files/{fileName}.txt"))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					yield return line;
				}
			}
		}

		public void WriteLine(string message, string fileName)
		{
			using (StreamWriter sw = new StreamWriter($"../../../Files/{fileName}.txt"))
			{
				sw.WriteLine(message);
			}
		}

		public bool CheckIfFileExists(string fileName)
		{
			if (File.Exists($"../../../Files/{fileName}.txt")) return true;
			return false;
		}
	}
}
