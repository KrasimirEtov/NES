using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NES.Core.Engine.Contracts;
using NES.Entities.Assets.Contracts;
using NES.Entities.Broker;
using NES.Entities.Users.Contracts;
using NES.Entities.Wallets.Contracts;
using NES.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TradeMarket.Contracts;

namespace NES.Tests.BrokerTests
{
    [TestClass]
    public class Sell_Should
    {
        [TestMethod]
        public void Add_AssetPrice_MultipliedByAmount_To_WalletCash()
        {
            string asset = "bitcoin";
            decimal assetPrice = 3000;

            var user = new Mock<IUser>();
            var wallet = new Mock<IWallet>();
            var market = new Mock<IMarket>();
            var factory = new Mock<IAssetFactory>();
			var consoleManager = new Mock<IConsoleManager>();
			var printerManager = new Mock<IPrinterManager>();

			market.Setup(x => x.AssetPrice(asset)).Returns(assetPrice);
            user.Setup(x => x.Wallet).Returns(wallet.Object);
            wallet.SetupAllProperties();

            var broker = new Broker(factory.Object, market.Object, consoleManager.Object, printerManager.Object);
            try
            {
                string result = broker.Sell(asset, 1, user.Object);
            }
            catch (DirectoryNotFoundException)
            {

            }

            Assert.AreEqual(assetPrice, user.Object.Wallet.Cash);
        }

        [TestMethod]
        public void GetPrice_From_Market()
        {
            string asset = "bitcoin";
            var user = new Mock<IUser>();
            var wallet = new Mock<IWallet>();
            var market = new Mock<IMarket>();
            var factory = new Mock<IAssetFactory>();
			var consoleManager = new Mock<IConsoleManager>();
			var printerManager = new Mock<IPrinterManager>();

			user.Setup(x => x.Wallet).Returns(wallet.Object);
            wallet.Setup(x => x.Cash).Returns(0);
            market.Setup(x => x.AssetPrice(asset)).Returns(3000);

            var broker = new Broker(factory.Object, market.Object, consoleManager.Object, printerManager.Object);

            try
            {
                string result = broker.Buy(asset, 1, user.Object);
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
            string message = $"Succesfully selled {amount} {assetName} " + (amount > 1 ? "assets" : "asset");

            var user = new Mock<IUser>();
            var wallet = new Mock<IWallet>();
            var market = new Mock<IMarket>();
            var factory = new Mock<IAssetFactory>();

            user.Setup(x => x.Wallet).Returns(wallet.Object);

            wallet.Setup(x => x.Cash).Returns(cash);

            market.Setup(x => x.AssetPrice(assetName)).Returns(price);

            var broker = new BrokerMock(factory.Object, market.Object);
            string result = broker.Sell(assetName, amount, user.Object);

            Assert.AreEqual(message, result);
        }

        [TestMethod]
        public void Invoke_WalletRemoveAsset()
        {
            string assetName = "bitcoin";
            decimal price = 3000;
            int amount = 1;
            string message = $"Succesfully purchased {amount} {assetName} " + (amount > 1 ? "assets" : "asset");

            var user = new Mock<IUser>();
            var wallet = new Mock<IWallet>();
            var market = new Mock<IMarket>();
            var factory = new Mock<IAssetFactory>();
            var asset = new Mock<IAsset>();

            user.Setup(x => x.Wallet).Returns(wallet.Object);

            factory.Setup<IAsset>(x => x.CreateAsset(assetName, price, amount)).Returns(asset.Object);

            wallet.Setup(x => x.RemoveAsset(asset.Object));

            market.Setup(x => x.AssetPrice(assetName)).Returns(price);

            var broker = new BrokerMock(factory.Object, market.Object);
            string result = broker.Sell(assetName, amount, user.Object);

            wallet.Verify(x => x.RemoveAsset(asset.Object), Times.Once);
        }
    }
}
