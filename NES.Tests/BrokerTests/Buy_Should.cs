using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NES.Core.Commands;
using NES.Core.Engine.Contracts;
using NES.Entities.Broker;
using NES.Entities.Users.Contracts;
using NES.Entities.Wallets.Contracts;
using System;
using System.Reflection;
using TradeMarket;
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

            user.Setup(x => x.Wallet).Returns(wallet.Object);
            wallet.Setup(x => x.Cash).Returns(0);
            market.Setup(x => x.AssetPrice(asset)).Returns(3000);

            var broker = new Broker(factory.Object, market.Object);

            string result = broker.Buy(asset, 1, user.Object);
        }

        [TestMethod]
        public void GetPrice_From_Market()
        {
            string asset = "bitcoin";
            var user = new Mock<IUser>();
            var wallet = new Mock<IWallet>();
            var market = new Mock<IMarket>();
            var factory = new Mock<IAssetFactory>();

            user.Setup(x => x.Wallet).Returns(wallet.Object);
            wallet.Setup(x => x.Cash).Returns(0);
            market.Setup(x => x.AssetPrice(asset)).Returns(3000);

            var broker = new Broker(factory.Object, market.Object);

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
