using NES.Core.Engine;
using NES.Core.Engine.Contracts;
using NES.Core.Providers;
using NES.Entities.Users.Contracts;
using NES.Entities.Wallets;
using NES.Entities.Wallets.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NES.Entities.Users
{
    public class UserHandler
    {
        private const string usersFileName = "RegisteredUsers";
        private const string walletName = "Wallet";

        private IUserFactory userFactory = UserFactory.Instance;
        private string name;
        private string password;
        private decimal cash;

        protected string Name
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

        protected string Password
        {
            get => password;
            set
            {
                if (value == null) throw new ArgumentNullException("Password cannot be null!");
                if (value.Length < 1 || value.Length > 50) throw new ArgumentOutOfRangeException("Password length cannot be less than 1 or more than 50 characters!");
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
        
        public IUser LoginUser(IList<string> parameters)
        {
            if (parameters.Count != 2)
            {
                throw new InitialCustomException($"Invalid login parameters!");
            }
            this.Name = parameters[0];
            this.Password = parameters[1];

            if (!CheckName(this.Name))
            {
                throw new InitialCustomException($"User with name \"{Name}\" is not registered.");
            }
            if (!CheckPass(this.Name, this.Password))
            {
                throw new InitialCustomException("Invalid password.");
            }

            return userFactory.CreateUser(name, IOStream.BinaryRead($"{Name}{walletName}"));
        }

        public IUser RegisteUser(IList<string> parameters)
        {
            if (parameters.Count != 3)
            {
                throw new InitialCustomException($"Invalid register parameters!");
            }
            this.Name = parameters[0];
            this.Password = parameters[1];
            this.Cash = decimal.Parse(parameters[2]);

            if (CheckName(this.Name))
            {
                throw new InitialCustomException($"User with name \"{Name}\" is already registered.");
            }

            IWallet wallet = new Wallet(cash);
            IOStream.WriteLineAppend(GenerateUserInfo(Name, Password, Cash), usersFileName);
            IOStream.BinaryWrite(wallet, $"{Name}{walletName}");

            Printer.InitialInstructions();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your registration is complete. You can login now!");
            Console.ResetColor();

            return userFactory.CreateUser(name, wallet);
        }


        private bool CheckName(string userName)
        {
            if (!File.Exists($"../../../Files/{usersFileName}.txt")) return false;

            foreach (var read in IOStream.ReadLine(usersFileName))
            {
                var nameFromFile = read.Substring(0, read.IndexOf('|'));
                if (nameFromFile.Equals(userName)) return true;
            }

            return false;
        }

        private bool CheckPass(string userName, string password)
        {
            if (!File.Exists($"../../../Files/{usersFileName}.txt")) return false;
            foreach (var read in IOStream.ReadLine(usersFileName))
            {
                string[] data = read.Split('|');
                if ((data[0].Equals(userName)) && (data[1].Equals(password))) return true;
            }

            return false;
        }

        private string GenerateUserInfo(string name, string password, decimal cash)
        {
            StringBuilder temp = new StringBuilder();
            temp.Append(name);
            temp.Append('|');
            temp.Append(password);
            return temp.ToString();
        }
    }
}
