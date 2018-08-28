using NES.Core.Engine.Contracts;
using NES.Entities.Wallets.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NES.Core.Providers
{
	public class IOStream : IStreamManager
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

		public void WriteLineAppend(string message, string fileName)
		{
			using (StreamWriter sw = new StreamWriter($"../../../Files/{fileName}.txt", true))
			{
				sw.WriteLine(message);
			}
		}

		public void BinaryWrite(IWallet wallet, string fileName)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream writerFileStream = new FileStream($"../../../Files/{fileName}.bin", FileMode.Create, FileAccess.Write))
			{
				formatter.Serialize(writerFileStream, wallet);
			}
		}

		public IWallet BinaryRead(string fileName)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream readerFileStream = new FileStream($"../../../Files/{fileName}.bin", FileMode.Open, FileAccess.Read))
			{
				return (IWallet)formatter.Deserialize(readerFileStream);
			}
		}

		public string ReadAllText(string fileName)
		{
			return File.ReadAllText($"../../../Files/ConsoleMenus/{fileName}.txt");
		}

		public bool CheckIfFileExists(string fileName)
		{
			if (File.Exists($"../../../Files/{fileName}.txt")) return true;
			return false;
		}

		public bool CheckName(string userName, string fileName)
		{
			if (!CheckIfFileExists(fileName)) return false;

			foreach (var read in ReadLine(fileName))
			{
				var nameFromFile = read.Substring(0, read.IndexOf('|'));
				if (nameFromFile.Equals(userName)) return true;
			}

			return false;
		}

		public bool CheckPass(string userName, string password, string fileName)
		{
			if (!CheckIfFileExists(fileName)) return false;
			foreach (var read in ReadLine(fileName))
			{
				string[] data = read.Split('|');
				if ((data[0].Equals(userName)) && (data[1].Equals(password))) return true;
			}

			return false;
		}

		public void SaveWallet(IWallet wallet, string userName)
		{
			BinaryWrite(wallet, $"{userName}Wallet");
		}
	}
}
