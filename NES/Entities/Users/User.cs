using NES.Entities.Users.Contracts;
using NES.Entities.Wallets;
using NES.Entities.Wallets.Contracts;
using System;

namespace NES.Entities.Users
{
	public class User : IUser
	{
		private string name;
		private int age;
		private IWallet wallet;

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

		public int Age
		{
			get => age;
			set
			{
				if (value < 0) throw new ArgumentOutOfRangeException("Age cannot be negative!");
				if (value < 18 || value > 100) throw new ArgumentOutOfRangeException("Enter valid age!");
				age = value;
			}
		}

		public IWallet Wallet
		{
			get => wallet;
			set
			{
				wallet = value ?? throw new ArgumentNullException("Wallet cannot be null");
			}
		}

		public User(string name, int age, decimal cash)
		{
			Wallet = new Wallet(cash);
			Name = name;
			Age = age;
		}
	}
}
