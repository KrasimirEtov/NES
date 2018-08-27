using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NES.Entities.Wallets;
using NES.Entities.Wallets.Contracts;

namespace NES.Tests.WalletTests
{
	[TestClass]
	public class Properties_Should
	{
		[TestMethod]
		public void ReturnCashGetValueCorrectly_WhenInvoked()
		{
			// Arrange
			var cash = 10000;
			var walletMock = new Mock<IWallet>();
			walletMock.SetupGet(x => x.Cash).Returns(cash);

			// Act && Assert
			var expected = walletMock.Object.Cash;
			walletMock.VerifyGet(x => x.Cash, Times.Once);
			//Assert.AreEqual(expected, cash);

		}

		[TestMethod]
		public void SetCashValueCorrectly_WhenInvoked()
		{
			// Arrange
			var wallet = new Wallet(200);
			var walletMock = new Mock<IWallet>();

			// Act && Assert

			wallet.Cash = 50;
			Assert.AreEqual(50, wallet.Cash);
		}
	}
}
