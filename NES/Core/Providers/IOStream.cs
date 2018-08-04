using NES.Entities.Wallets.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NES.Core.Providers
{
	static public class IOStream
	{
		public static IEnumerable<string> ReadLine(string fileName)
		{
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

		public static void BinaryWrite(IWallet wallet, string fileName)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream writerFileStream = new FileStream($"../../../Files/{fileName}.bin", FileMode.Create, FileAccess.Write))
			{
				formatter.Serialize(writerFileStream, wallet);
			}
		}

		public static IWallet BinaryRead(string fileName)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream readerFileStream = new FileStream($"../../../Files/{fileName}.bin", FileMode.Open, FileAccess.Read))
			{
				return (IWallet)formatter.Deserialize(readerFileStream);
			}
		}
	}
}
