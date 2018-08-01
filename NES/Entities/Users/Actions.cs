using NES.Entities.Users.Contracts;
using NES.Entities.Wallets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Entities.Users
{
	public class Actions : IActions
	{
		private IWallet wallet;
		private IUser user;

		public IWallet Wallet
		{
			get => wallet;
			set
			{
				wallet = value ?? throw new ArgumentNullException("Wallet cannot be null!");
			}
		}

		public IUser User
		{
			get => user;
			set
			{
				user = value ?? throw new ArgumentNullException("User cannot be null!");
			}
		}

		public void Buy()
		{
			throw new NotImplementedException();
		}

		public void Sell()
		{
			throw new NotImplementedException();
		}
	}
}
