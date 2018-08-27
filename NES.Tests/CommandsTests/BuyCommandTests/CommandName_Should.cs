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
    public class CommandName_Should
    {
        [TestMethod]
        public void ThrowException_WhenPassedDataContainsOnlyNumbers()
        {
            //Arrange
            Mock<IBroker> brockerMock = new Mock<IBroker>();
            BuyCommand buyCommand = new BuyCommand(brockerMock.Object);

            string testName = "123";

            //Act & Assert
            Assert.ThrowsException<Exception>(() => buyCommand.CommandName = testName);
        }

        [TestMethod]
        public void ThrowException_WhenPassedDataIsNull()
        {
            //Arrange
            Mock<IBroker> brockerMock = new Mock<IBroker>();
            BuyCommand buyCommand = new BuyCommand(brockerMock.Object);

            string testName = null;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => buyCommand.CommandName = testName);
        }

        [TestMethod]
        public void ThrowException_WhenPassedDataIsTooShort()
        {
            //Arrange
            Mock<IBroker> brockerMock = new Mock<IBroker>();
            BuyCommand buyCommand = new BuyCommand(brockerMock.Object);

            string testName = "";

            //Act & Assert
            Assert.ThrowsException<Exception>(() => buyCommand.CommandName = testName);
        }

        [TestMethod]
        public void ThrowException_WhenPassedDataIsTooLong()
        {
            //Arrange
            Mock<IBroker> brockerMock = new Mock<IBroker>();
            BuyCommand buyCommand = new BuyCommand(brockerMock.Object);

            string testName = "TooLongStringggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg";

            //Act & Assert
            Assert.ThrowsException<Exception>(() => buyCommand.CommandName = testName);
        }

        [TestMethod]
        public void CorrectlyAssignValue_WhenValidDataIsPassed()
        {
            //Arrange
            Mock<IBroker> brockerMock = new Mock<IBroker>();
            BuyCommand buyCommand = new BuyCommand(brockerMock.Object);

            string testName = "TestCommandName";

            //Act 
            buyCommand.CommandName = testName;

            //Assert
            Assert.AreEqual("TestCommandName", buyCommand.CommandName);            
        }
    }
}
