using NES.Core.Providers;
using NES.Entities.Users.Abstracts;
using NES.Entities.Users.Contracts;
using NES.Entities.Wallets.Contracts;
using System;
using System.IO;

namespace NES.Entities.Users
{
	public class Login : Authentication
    {
		private IWallet wallet;

		public IWallet Wallet
		{
			get => wallet;
			set
			{
				wallet = value ?? throw new ArgumentNullException("Wallet cannot be null");
			}
		}

		public Login()
		{
			EnterUserInfo();
			if (!CheckIfUserExists(Name, Password)) throw new ArgumentException("That user is not registered!");
		}

		public IUser CreateUser()
		{
			return new User(Name, IOStream.BinaryRead($"{Name}{walletName}"));
		}

		protected override void EnterUserInfo()
		{
			Console.WriteLine("Hello!\nType:'username' 'password' seperated by whitespace in order to login");
			string[] input = Console.ReadLine().Split(' ');
			Name = input[0];
			Password = input[1];
		}

		private bool CheckIfUserExists(string name, string password)
		{
			if (!File.Exists($"../../../Files/{usersFileName}.txt")) return false;
			foreach (var read in IOStream.ReadLine(usersFileName))
			{
				string[] data = read.Split('|');
				if ((data[0].Equals(name)) && (data[1].Equals(password))) return true; // there is already such a name in the file
			}
			return false;
		}

	}
}
