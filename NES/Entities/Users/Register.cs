using NES.Core.Providers;
using NES.Entities.Users.Abstracts;
using System;
using System.IO;
using System.Text;

namespace NES.Entities.Users
{
	public class Register : Authentication
	{
		public Register()
		{
			EnterUserInfo();
			if (CheckIfUserExists(Name)) throw new ArgumentException("That user is already registered");
			IOStream.WriteLineAppend(GenerateUserInfo(Name, Password, Cash), usersFileName); // saves info to Users.txt
			IOStream.WriteLine(Cash.ToString(), $"{Name}{walletName}"); // saves a new wallet in a file for the current user
		}

		protected override void EnterUserInfo()
		{
			Console.WriteLine("Welcome\nType: 'username' 'password' 'cash' seperated by whitespace");
			string[] input = Console.ReadLine().Split(' ');
			Name = input[0];
			Password = input[1];
			Cash = decimal.Parse(input[2]); // needs proper validation
		}

		private string GenerateUserInfo(string name, string password, decimal cash)
		{
			StringBuilder temp = new StringBuilder();
			temp.Append(name);
			temp.Append('|');
			temp.Append(password);
			return temp.ToString();
		}

		private bool CheckIfUserExists(string name)
		{
			if (!File.Exists($"../../../Files/{usersFileName}.txt")) return false;
			foreach (var read in IOStream.ReadLine(usersFileName))
			{
				var nameFromFile = read.Substring(0, read.IndexOf('|'));
				if (nameFromFile.Equals(name)) return true; // there is already such a name in the file
			}
			return false;
		}
	}
}
