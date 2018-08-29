using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NES.Core.Engine.Contracts;
using NES.Entities.Users.Contracts;
using NES.Tests.Mocks;
using TradeMarket.Contracts;

namespace NES.Tests.BrokerTests
{
    [TestClass]
    public class EndDayTraiding_Should
    {
        [TestMethod]
        public void Incoke_MarkedUpdatePrices()
        {
            var factory = new Mock<IAssetFactory>();
            var market = new Mock<IMarket>();
            var user = new Mock<IUser>();
			var userSession = new Mock<IUserSession>();

			market.Setup(x => x.UpdatePrices());

			var broker = new BrokerMock(factory.Object, market.Object, userSession.Object);
			broker.EndDayTraiding();

            market.Verify(x => x.UpdatePrices(), Times.Once);
        }


        [TestMethod]
        public void Returns_Success_Message()
        {
            string message = "Trading day has ended!";
            var factory = new Mock<IAssetFactory>();
            var market = new Mock<IMarket>();
            var user = new Mock<IUser>();
			var userSession = new Mock<IUserSession>();

			market.Setup(x => x.UpdatePrices());

			var broker = new BrokerMock(factory.Object, market.Object, userSession.Object);
			string result = broker.EndDayTraiding();

            Assert.AreEqual(message, result);
        }
    }
}
