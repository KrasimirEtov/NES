using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Users.Abstracts
{
    public abstract class Authentication
    {
		protected const string usersFileName = "RegisteredUsers";
		protected const string walletName = "Wallet";
		private string name;
		private string password;
		private decimal cash;

		protected string Name
		{
			get => name;
			set
			{
				if (value == null) throw new ArgumentNullException("Name cannot be null!");
				if (value.Length < 1 || value.Length > 50) throw new ArgumentOutOfRangeException("Name length cannot be less than 1 or more than 50 characters!");
				name = value;
			}
		}

		protected string Password
		{
			get => password;
			set
			{
				if (value == null) throw new ArgumentNullException("Name cannot be null!");
				if (value.Length < 1 || value.Length > 50) throw new ArgumentOutOfRangeException("Name length cannot be less than 1 or more than 50 characters!");
				password = value;
			}
		}

		protected decimal Cash
		{
			get => cash;
			set
			{
				if (value < 1) throw new ArgumentOutOfRangeException("You are broke!");
				cash = value;
			}
		}

		protected abstract void EnterUserInfo();
	}
}
