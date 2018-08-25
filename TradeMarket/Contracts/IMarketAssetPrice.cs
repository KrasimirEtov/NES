namespace TradeMarket.Contracts
{
    public interface IMarketAssetPrice
    {
        string Category { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}