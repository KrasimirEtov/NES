//using NES.Core.Providers;
//using NES.Entities.Users.Abstracts;
//using NES.Entities.Wallets;
//using System;
//using System.IO;
//using System.Text;

//namespace NES.Entities.Users
//{
//	public class Register : Authentication
//	{
//		public Register()
//		{ 
//			Printer.PrintStartup();
//			EnterUserInfo();
//			if (CheckIfUserExists(Name))
//			{
//				throw new InitialCustomException($"User with name \"{Name}\" is already registered.");
//			}
//			IOStream.WriteLineAppend(GenerateUserInfo(Name, Password, Cash), usersFileName); 
//			IOStream.BinaryWrite(new Wallet(Cash), $"{Name}{walletName}"); 

//			Printer.InitialInstructions();
//			Console.ForegroundColor = ConsoleColor.Green;
//			Console.WriteLine("Your registration is complete. You can login now!");
//			Console.ResetColor();
//		}

//		protected override void EnterUserInfo()
//		{
//			Console.WriteLine("Type: 'username' 'password' 'cash' seperated by whitespace in order to register\n");
//			string[] input = Console.ReadLine().Split(' ');
//			if (input.Length != 3) throw new InitialCustomException("Input was not in correct format");
//			Name = input[0];
//			Password = input[1];
//			if (decimal.TryParse(input[2], out var cash))
//			{
//				Cash = cash;
//			}
//			else
//			{
//				throw new InitialCustomException("Incorrent input for cash!");
//			}
//		}

//		private string GenerateUserInfo(string name, string password, decimal cash)
//		{
//			StringBuilder temp = new StringBuilder();
//			temp.Append(name);
//			temp.Append('|');
//			temp.Append(password);
//			return temp.ToString();
//		}

//		private bool CheckIfUserExists(string userName)
//		{
//			if (!File.Exists($"../../../Files/{usersFileName}.txt")) return false;
//			foreach (var read in IOStream.ReadLine(usersFileName))
//			{
//				var nameFromFile = read.Substring(0, read.IndexOf('|'));
//				if (nameFromFile.Equals(userName)) return true;
//			}

//			return false;
//		}
//	}
//}
