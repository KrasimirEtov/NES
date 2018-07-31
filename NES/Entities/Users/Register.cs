using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NES.Entities.Users
{
	public class Register
	{
		private string name;
		private string password;
		private decimal cash;
		private StreamWriter writer;
		private StreamReader reader;

		// this can be in abstract class - but not sure if it's gonna be used
		public string Name
		{
			get => name;
			private set
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
			get => Cash;
			set
			{
				if (value < 1) throw new ArgumentOutOfRangeException("You are broke!");
				cash = value;
			}
		}

		public StreamWriter Writer
		{
			get => writer;
			private set
			{
				writer = value ?? throw new ArgumentNullException("StreamWriter cannot be null!");
			}
		}

		public StreamReader Reader
		{
			get => reader;
			private set
			{
				reader = value ?? throw new ArgumentNullException("StreamReader cannot be null!");
			}
		}

		public Register(string name)
		{
			Writer = new StreamWriter("D:\\Programming\\Projects\\C#\\Telerik\\Teamworks\\users.txt", true);
			Writer.Close();
			Reader = new StreamReader("D:\\Programming\\Projects\\C#\\Telerik\\Teamworks\\users.txt");
			if (CheckIfUserExists(name)) throw new ArgumentException("User already exist in the database :D");
			Reader.Close();
			Writer = new StreamWriter("D:\\Programming\\Projects\\C#\\Telerik\\Teamworks\\users.txt", true);
		}


		public string RegisterUser(string name, string password, decimal cash)
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
			string line;
			if (!File.Exists("D:\\Programming\\Projects\\C#\\Telerik\\Teamworks\\users.txt")) throw new ArgumentException("No such file");
			while ((line = Reader.ReadLine()) != null)
			{
				var nameFromFile = line.Substring(0, line.IndexOf('|'));
				if (nameFromFile.Equals(name)) return true; // there is already such a name in the file
			}
			return false;
		}
	}
}
