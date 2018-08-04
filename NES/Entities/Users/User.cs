using NES.Entities.Users.Contracts;
using NES.Entities.Wallets;
using NES.Entities.Wallets.Contracts;
using System;

namespace NES.Entities.Users
{
	public class User : IUser
	{
		private string name;
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

		public IWallet Wallet
		{
			get => wallet;
			set
			{
				wallet = value ?? throw new ArgumentNullException("Wallet cannot be null");
			}
		}

		public User(string name, decimal cash)
		{
			Name = name;
			Wallet = new Wallet(cash);
		}
	}
}
