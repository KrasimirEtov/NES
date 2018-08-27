using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using TradeMarket.Contracts;

namespace NES.Core.Engine.Contracts
{
	public interface IPrinterManager
	{
		void PrintStartup();
		void PrintMarketName();
		void InitialInstructions();
		void PrintUserInfo(IUser user);
		void PrintMarket(IUser user, IMarket Market);
	}
}
