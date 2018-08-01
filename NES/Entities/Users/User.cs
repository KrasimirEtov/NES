using NES.Entities.Wallets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Users
{
    public class User
    {
		private string name;
		private int age;
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

		public decimal Cash
		{
			get => Cash;
			set
			{
				if (value < 1) throw new ArgumentOutOfRangeException("You are broke!");
				cash = value;
			}
		}

		public User(string name, int age, decimal cash)
		{
			Name = name;
			Age = age;
			Cash = cash;
		}
	}
}
