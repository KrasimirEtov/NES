using NES.Core.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NES.Entities.Users
{
	public class Register
    {
		private const string userFileName = "Users";
		private string name;
		private string password;
		private decimal cash;

		public string Name
		{
			get => name;
			set
			{
				if (value == null) throw new ArgumentNullException("Name cannot be null!");
				if (value.Length < 1 || value.Length > 50) throw new ArgumentOutOfRangeException("Name length cannot be less than 1 or more than 50 characters!");
				name = value;
			}
		}

		public string Password
		{
			private get => password;
			set
			{
				if (value == null) throw new ArgumentNullException("Name cannot be null!");
				if (value.Length < 1 || value.Length > 50) throw new ArgumentOutOfRangeException("Name length cannot be less than 1 or more than 50 characters!");
				password = value;
			}
		}

		public decimal Cash
		{
			get => cash;
			set
			{
				if (value < 1) throw new ArgumentOutOfRangeException("You are broke!");
				cash = value;
			}
		}

		public Register(string name, string password, decimal cash)
		{
			Name = name;
			Password = password;
			Cash = cash;
			if (CheckIfUserExists(name)) throw new ArgumentException("That user is already registered");
			IOStream.WriteLine(GenerateUserInfo(Name, Password, Cash), userFileName);
		}


		public string GenerateUserInfo(string name, string password, decimal cash)
		{
			StringBuilder temp = new StringBuilder();
			temp.Append(name);
			temp.Append('|');
			temp.Append(password);
			temp.Append('|');
			temp.Append(cash);
			return temp.ToString();
		}

		public bool CheckIfUserExists(string name)
		{
			if (!File.Exists($"../../../{userFileName}.txt")) return false;
			foreach (var read in IOStream.ReadLine(userFileName))
			{
				var nameFromFile = read.Substring(0, read.IndexOf('|'));
				if (nameFromFile.Equals(name)) return true; // there is already such a name in the file
			}
			return false;
		}
	}
}
