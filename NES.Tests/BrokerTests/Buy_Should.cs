using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Broker;
using NES.Entities.Users.Contracts;
using NES.Entities.Wallets.Contracts;
using NES.Tests.Mocks;
using System;
using TradeMarket.Contracts;

namespace NES.Tests.BrokerTests
{
    [TestClass]
    public class Buy_Should
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Throw_When_UserWalletCash_IsLessThan_AssetPrice()
        {
            string asset = "bitcoin";
            var user = new Mock<IUser>();
            var wallet = new Mock<IWallet>();
            var market = new Mock<IMarket>();
            var factory = new Mock<IAssetFactory>();
			var consoleManager = new Mock<IOManager>();
			var printerManager = new Mock<IPrinterManager>();
			var userSession = new Mock<IUserSession>();

			user.Setup(x => x.Wallet).Returns(wallet.Object);
            wallet.Setup(x => x.Cash).Returns(0);
            market.Setup(x => x.AssetPrice(asset)).Returns(3000);
			userSession.Setup(x => x.User).Returns(user.Object);

			var broker = new Broker(factory.Object, market.Object, consoleManager.Object, printerManager.Object, userSession.Object);

            string result = broker.Buy(asset, 1);
        }

        [TestMethod]
        public void GetPrice_From_Market()
        {
            string asset = "bitcoin";
            var user = new Mock<IUser>();
            var wallet = new Mock<IWallet>();
            var market = new Mock<IMarket>();
            var factory = new Mock<IAssetFactory>();
			var consoleManager = new Mock<IOManager>();
			var printerManager = new Mock<IPrinterManager>();
			var userSession = new Mock<IUserSession>();

			user.Setup(x => x.Wallet).Returns(wallet.Object);
            wallet.Setup(x => x.Cash).Returns(0);
            market.Setup(x => x.AssetPrice(asset)).Returns(3000);
			userSession.Setup(x => x.User).Returns(user.Object);


			var broker = new BrokerMock(factory.Object, market.Object, userSession.Object);

			try
			{
                string result = broker.Buy(asset, 1);
            }
            catch (ArgumentException)
            {

            }

            market.Verify(x => x.AssetPrice(asset), Times.Once);
        }

        [TestMethod]
        public void Return_SuccessMessage()
        {
            string assetName = "bitcoin";
            decimal price = 3000;
            decimal cash = 10000;
            int amount = 1;
            string message = $"Succesfully purchased {amount} {assetName} " + (amount > 1 ? "assets" : "asset");

            var user = new Mock<IUser>();
            var wallet = new Mock<IWallet>();
            var market = new Mock<IMarket>();
            var factory = new Mock<IAssetFactory>();
			var userSession = new Mock<IUserSession>();

			user.Setup(x => x.Wallet).Returns(wallet.Object);
            
            wallet.Setup(x => x.Cash).Returns(cash);

            market.Setup(x => x.AssetPrice(assetName)).Returns(price);

			userSession.Setup(x => x.User).Returns(user.Object);

			var broker = new BrokerMock(factory.Object, market.Object, userSession.Object);
            string result = broker.Buy(assetName, amount);

            Assert.AreEqual(message, result);
        }

        [TestMethod]
        public void Decreases_WalletCash()
        {
            string assetName = "bitcoin";
            decimal price = 3000;
            decimal cash = 10000;
            int amount = 1;
            string message = $"Succesfully purchased {amount} {assetName} " + (amount > 1 ? "assets" : "asset");

            var user = new Mock<IUser>();
            var wallet = new Mock<IWallet>();
            var market = new Mock<IMarket>();
            var factory = new Mock<IAssetFactory>();
			var userSession = new Mock<IUserSession>();

			userSession.Setup(x => x.User.Wallet).Returns(wallet.Object);

            wallet.SetupProperty(x => x.Cash, cash);

            market.Setup(x => x.AssetPrice(assetName)).Returns(price);

            var broker = new BrokerMock(factory.Object, market.Object, userSession.Object);
            string result = broker.Buy(assetName, amount);

            Assert.AreEqual(cash - price, wallet.Object.Cash);
        }

        [TestMethod]
        public void Invoke_WalletAddAsset()
        {
            string assetName = "bitcoin";
            decimal price = 3000;
            decimal cash = 10000;
            int amount = 1;
            string message = $"Succesfully purchased {amount} {assetName} " + (amount > 1 ? "assets" : "asset");

            var user = new Mock<IUser>();
            var wallet = new Mock<IWallet>();
            var market = new Mock<IMarket>();
            var factory = new Mock<IAssetFactory>();
            var asset = new Mock<IAsset>();
			var userSession = new Mock<IUserSession>();

			user.Setup(x => x.Wallet).Returns(wallet.Object);
			userSession.Setup(x => x.User.Wallet).Returns(wallet.Object);
			factory.Setup<IAsset>(x => x.CreateAsset(assetName, price, amount)).Returns(asset.Object);

            wallet.SetupProperty(x => x.Cash, cash);
            wallet.Setup(x => x.AddAsset(asset.Object));

            market.Setup(x => x.AssetPrice(assetName)).Returns(price);

			var broker = new BrokerMock(factory.Object, market.Object, userSession.Object);
			string result = broker.Buy(assetName, amount);

            wallet.Verify(x => x.AddAsset(asset.Object), Times.Once);
        }
    }
}
