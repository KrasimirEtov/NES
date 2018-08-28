namespace NES.Entities.Broker.Contracts
{
	public interface IBroker
	{
		string EndDayTraiding();
		string Buy(string assetName, decimal amount);
        string Sell(string assetName, decimal amount);
    }
}
