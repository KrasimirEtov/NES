using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TradeMarket.Providers
{
	static public class IOStream
	{
		public static IEnumerable<string> ReadLine(string fileName)
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

		public static void WriteLine(string message, string fileName)
		{
			using (StreamWriter sw = new StreamWriter($"../../../Files/{fileName}.txt"))
			{
				sw.WriteLine(message);
			}
		}

		public static void WriteLineAppend(string message, string fileName)
		{
			using (StreamWriter sw = new StreamWriter($"../../../Files/{fileName}.txt", true))
			{
				sw.WriteLine(message);
			}
		}
        
		public static string ReadAllText(string fileName)
		{
			return File.ReadAllText($"../../../Files/ConsoleMenus/{fileName}.txt");
		}

		public static bool CheckIfFileExists(string fileName)
		{
			if (File.Exists($"../../../Files/{fileName}.txt")) return true;
			return false;
		}
	}
}
