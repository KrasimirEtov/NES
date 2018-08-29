using NES.Entities.Users.Contracts;
using TradeMarket.Contracts;

namespace NES.Core.Engine.Contracts
{
	public interface IPrinterManager
	{
		void PrintStartup();
		void PrintMarketName();
		void InitialInstructions();
		void PrintUserInfo(IUser user);
		void PrintMarket(IUser user, IMarket market);
		string PrintWallet(IUser user);
	}
}
