using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NES.Core.Commands;
using NES.Entities.Broker.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Tests.CommandsTests.BuyCommandTests
{
    [TestClass]
    public class Amount_Should
    {
        [TestMethod]
        public void ThrowException_WhenInvalidDataIsPassed()
        {
            //Arrange
            Mock<IBroker> brockerMock = new Mock<IBroker>();
            BuyCommand buyCommand = new BuyCommand(brockerMock.Object);

            int amount = 0;

            //Act & Assert
            Assert.ThrowsException<Exception>(() => buyCommand.Amount = amount);
        }

        [TestMethod]
        public void CorrectlyAssignValue_WhenValidDataIsPassed()
        {
            //Arrange
            Mock<IBroker> brockerMock = new Mock<IBroker>();
            BuyCommand buyCommand = new BuyCommand(brockerMock.Object);

            int amount = 10;

            //Act
            buyCommand.Amount = amount;

            //Assert
            Assert.AreEqual(amount, buyCommand.Amount);
        }
    }
}
