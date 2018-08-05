using NES.Entities.Users.Contracts;

namespace NES.Entities.Broker.Contracts
{
	public interface IBroker
	{
		void EndDayTraiding(IUser user);
		void Buy(string assetName, decimal amount, IUser user);
        void Sell(string assetName, decimal amount, IUser user);
    }
}
