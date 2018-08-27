using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NES.Entities.Assets.Contracts;
using NES.Entities.Wallets;
using System;

namespace NES.Tests.WalletTests
{
	[TestClass]
	public class RemoveAsset_Should
	{
		[TestMethod]
		public void ThrowArgumentException_WhenNoAssetIsFoundInPortfolio()
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

			// Assert
			Assert.ThrowsException<ArgumentException>(() => wallet.RemoveAsset(assetMock.Object));
		}

		[TestMethod]
		public void ThrowArgumentException_PortfolioAmountIsLessThanZero()
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

			assetMock2.SetupProperty(x => x.Price, assetPrice);
			assetMock2.Setup(x => x.Name).Returns(assetName);
			assetMock2.SetupProperty(x => x.Amount, assetAmount + 5);
			// Act

			var wallet = new Wallet(cash);
			wallet.AddAsset(assetMock.Object);

			// Assert
			Assert.ThrowsException<ArgumentException>(() => wallet.RemoveAsset(assetMock2.Object));
		}

		[TestMethod]
		public void RemoveAsset_When_PortfolioAmountIsZero()
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

			assetMock2.SetupProperty(x => x.Price, assetPrice);
			assetMock2.Setup(x => x.Name).Returns(assetName);
			assetMock2.SetupProperty(x => x.Amount, assetAmount);
			// Act

			var wallet = new Wallet(cash);
			wallet.AddAsset(assetMock.Object);
			wallet.AddAsset(assetMock2.Object);
			wallet.RemoveAsset(assetMock.Object);
			var actual = wallet.Portfolio.ContainsKey(assetName);
			// Assert
			Assert.AreEqual(false, actual);
		}
		[TestMethod]
		public void CalculateAmount_When_PortfolioAmountIsGreaterZero()
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
			assetMock.SetupProperty(x => x.Amount, assetAmount + 10);

			assetMock2.SetupProperty(x => x.Price, assetPrice);
			assetMock2.Setup(x => x.Name).Returns(assetName);
			assetMock2.SetupProperty(x => x.Amount, assetAmount);
			// Act

			var wallet = new Wallet(cash);
			wallet.AddAsset(assetMock.Object);

			wallet.RemoveAsset(assetMock2.Object);
			var actual = wallet.Portfolio[assetName].Amount;
			// Assert
			Assert.AreEqual(10, actual);
		}
	}
}
