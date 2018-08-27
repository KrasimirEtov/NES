using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NES.Entities.Assets.Contracts;
using NES.Entities.Assets.Enums;
using NES.Entities.Wallets;
using System.Text;

namespace NES.Tests.WalletTests
{
	[TestClass]
	public class PrintWallet_Should
	{
		[TestMethod]
		public void ReturnMessage_WhenWalletIsEmpty()
		{
			// Arrange
			var wallet = new Wallet(200);
			var expected = "You don't have any purchased assets!";

			// Act
			var actual = wallet.PrintWallet();

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ReturnAssetsInformation_WhenInvoked()
		{
			// Arrange
			string assetName = "Bitcoin";
			decimal assetPrice = 5000;
			int assetAmount = 2;
			var assetType = AssetType.CRIPTO;

			var wallet = new Wallet(200);
			var assetMock = new Mock<IAsset>();
			StringBuilder expected = new StringBuilder();

			assetMock.SetupProperty(x => x.Price, assetPrice);
			assetMock.Setup(x => x.Name).Returns(assetName);
			assetMock.SetupProperty(x => x.Amount, assetAmount);
			assetMock.SetupProperty(x => x.Type, assetType);

			expected.AppendLine("\n" + assetMock.Object.Type.ToString() + ":");
			expected.Append($"   {assetName}:");
			expected.AppendLine($" Amount: {assetAmount}, Price per unit: {assetPrice}");

			// Act
			wallet.AddAsset(assetMock.Object);
			var actual = wallet.PrintWallet();

			// Assert
			Assert.AreEqual(expected.ToString(), actual);
		}
	}
}
