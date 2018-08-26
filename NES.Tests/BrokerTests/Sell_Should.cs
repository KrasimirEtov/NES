using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NES.Core.Engine.Contracts;
using NES.Entities.Broker;
using NES.Entities.Users.Contracts;
using NES.Entities.Wallets.Contracts;
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
    }
}
