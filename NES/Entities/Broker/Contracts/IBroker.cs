using NES.Entities.Users.Contracts;

namespace NES.Entities.Broker.Contracts
{
	public interface IBroker
	{
		string EndDayTraiding(IUser user);
		string Buy(string assetName, decimal amount, IUser user);
        string Sell(string assetName, decimal amount, IUser user);
    }
}
