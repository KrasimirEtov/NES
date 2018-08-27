using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NES.Entities.Assets.Contracts;
using NES.Entities.Wallets;

namespace NES.Tests.WalletTests
{
	[TestClass]
	public class AddAsset_Should
	{
		[TestMethod]
		public void AddAsset_WhenItsNotInThePortfolio()
		{
			// Arrange
			string assetName = "Bitcoin";
			decimal cash = 10000;
			decimal assetPrice = 5000;
			int assetAmount = 1;

			var assetMock = new Mock<IAsset>();
			assetMock.Setup(x => x.Price).Returns(assetPrice);
			assetMock.Setup(x => x.Name).Returns(assetName);
			assetMock.Setup(x => x.Amount).Returns(assetAmount);

			// Act
			var wallet = new Wallet(cash);
			wallet.AddAsset(assetMock.Object);

			// Assert
			var actual = wallet.Portfolio[assetName];
			Assert.AreSame(assetMock.Object, actual);
		}

		[TestMethod]
		public void UpdatePrice_WhenAssetIsInThePortfolio()
		{
			// Arrange
			string assetName = "Bitcoin";
			decimal cash = 10000;
			decimal assetPrice = 5000;
			int assetAmount = 2;

			var assetMock = new Mock<IAsset>();
			var assetMock2 = new Mock<IAsset>();

			assetMock.SetupProperty(x => x.Price, assetPrice);
			assetMock.Setup(x => x.Name).Returns(assetName);
			assetMock.SetupProperty(x => x.Amount, assetAmount);

			assetMock2.SetupProperty(x => x.Price, assetPrice + 500);
			assetMock2.Setup(x => x.Name).Returns(assetName);
			assetMock2.SetupProperty(x => x.Amount, assetAmount);

			// Act

			var wallet = new Wallet(cash);
			wallet.AddAsset(assetMock.Object);
			wallet.AddAsset(assetMock2.Object);

			// Assert

			var actual = wallet.Portfolio[assetName].Price;
			Assert.AreEqual(5250, actual);
		}

		[TestMethod]
		public void UpdateAmount_WhenAssetIsInThePortfolio()
		{
			// Arrange
			string assetName = "Bitcoin";
			decimal cash = 10000;
			decimal assetPrice = 5000;
			int assetAmount = 2;

			var assetMock = new Mock<IAsset>();

			assetMock.SetupProperty(x => x.Price, assetPrice);
			assetMock.Setup(x => x.Name).Returns(assetName);
			assetMock.SetupProperty(x => x.Amount, assetAmount);

			// Act

			var wallet = new Wallet(cash);
			wallet.AddAsset(assetMock.Object);
			wallet.AddAsset(assetMock.Object);

			// Assert

			var actual = wallet.Portfolio[assetName].Amount;
			Assert.AreEqual(4, actual);
		}
	}
}