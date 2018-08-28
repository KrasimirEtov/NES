using NES.Core.Engine.Contracts;
using NES.Core.Providers;
using NES.Entities.Users.Contracts;
using NES.Entities.Wallets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NES.Entities.Users
{
    public class UserHandler : IUserHandler
    {
		private const string usersFileName = "RegisteredUsers";
		private const string walletName = "Wallet";

		private IUserFactory UserFactory { get; }
		private IStreamManager StreamManager { get; }
		private IOManager ConsoleManager { get; }
		private IPrinterManager PrinterManager { get; }
		private IUserSession UserSession { get; }

		public UserHandler(IUserFactory userFactory, IStreamManager streamManager, IOManager consoleManager, IPrinterManager printerManager, IUserSession userSession)
		{
			UserFactory = userFactory;
			StreamManager = streamManager;
			ConsoleManager = consoleManager;
			PrinterManager = printerManager;
			UserSession = userSession;
		}

		private string name;
		private string password;
		private decimal cash;

		private string Name
		{
			get => name;
			set
			{
				if (value.All(char.IsDigit)) throw new InitialCustomException("Name cannot contain only letters!");
				if (value == null) throw new ArgumentNullException("Name cannot be null!");
				if (value.Length < 1 || value.Length > 50) throw new ArgumentOutOfRangeException("Name length cannot be less than 1 or more than 50 characters!");
				name = value;
			}
		}

		private string Password
		{
			get => password;
			set
			{
				if (value == null) throw new ArgumentNullException("Password cannot be null!");
				if (value.Length < 1 || value.Length > 50) throw new ArgumentOutOfRangeException("Password length cannot be less than 1 or more than 50 characters!");
				password = value;
			}
		}

		private decimal Cash
		{
			get => cash;
			set
			{
				if (value < 1) throw new ArgumentOutOfRangeException("You are broke!");
				cash = value;
			}
		}

		public IUser LoginUser(IList<string> parameters)
		{
			if (UserSession.User != null)
			{
				throw new InitialCustomException("You are already logged in!");
			}

			if (parameters.Count != 2)
			{
				throw new InitialCustomException($"Invalid login parameters!");
			}
			this.Name = parameters[0];
			this.Password = parameters[1];

			if (!StreamManager.CheckName(this.Name, usersFileName))
			{
				throw new InitialCustomException($"User with name \"{Name}\" is not registered.");
			}
			if (!StreamManager.CheckPass(this.Name, this.Password, usersFileName))
			{
				throw new InitialCustomException("You have entered an invalid username or password");
			}

			return UserFactory.CreateUser(Name, StreamManager.BinaryRead($"{Name}{walletName}"));
		}

		public IUser RegisteUser(IList<string> parameters)
		{
			if (UserSession.User != null)
			{
				throw new InitialCustomException("Logout firts to register new account!");
			}

			if (parameters.Count != 3)
			{
				throw new InitialCustomException($"Invalid register parameters!");
			}
			this.Name = parameters[0];
			this.Password = parameters[1];
			if (decimal.TryParse(parameters[2], out var cash))
			{
				this.Cash = cash;
			}
			else
			{
				throw new InitialCustomException("Incorrent input for cash!");
			}

			if (StreamManager.CheckName(this.Name, usersFileName))
			{
				throw new InitialCustomException($"User with name \"{Name}\" is already registered.");
			}
			StreamManager.WriteLineAppend(GenerateUserInfo(Name, Password), usersFileName);

			IWallet wallet = UserFactory.CreateWallet(Cash);

			StreamManager.BinaryWrite(wallet, $"{Name}{walletName}");

			return UserFactory.CreateUser(Name, wallet);
		}

		private string GenerateUserInfo(string name, string password)
		{
			StringBuilder temp = new StringBuilder();
			temp.Append(name);
			temp.Append('|');
			temp.Append(password);
			return temp.ToString();
		}
	}
}
