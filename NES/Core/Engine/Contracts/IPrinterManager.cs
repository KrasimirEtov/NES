namespace NES.Core.Engine.Contracts
{
	public interface IPrinterManager
	{
		void PrintStartup();
		void PrintMarketName();
		void InitialInstructions();
		void PrintUserInfo();
		void PrintMarket();
		string PrintWallet();
	}
}
