using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NES.Core.Commands;
using NES.Entities.Broker.Contracts;
using NES.Entities.Users.Contracts;
using System;
using System.Collections.Generic;

namespace NES.Tests.CommandsTests.BuyCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ThrowException_WhenInvalidListIsPassed()
        {
            //Arrange
            Mock<IBroker> brockerMock = new Mock<IBroker>();
            BuyCommand buyCommand = new BuyCommand(brockerMock.Object);
            Mock<IUser> userMock = new Mock<IUser>();

            IList<string> input = new List<string>();

            //Act & Assert
            Assert.ThrowsException<Exception>(() => buyCommand.Execute(input));
        }

        [TestMethod]
        public void ThrowException_WhenInvalidAmountIsPassed()
        {
            //Arrange
            Mock<IBroker> brockerMock = new Mock<IBroker>();
            BuyCommand buyCommand = new BuyCommand(brockerMock.Object);
            Mock<IUser> userMock = new Mock<IUser>();

            IList<string> input = new List<string>();
            input.Add("String");
            input.Add("Int");

            //Act & Assert
            Assert.ThrowsException<Exception>(() => buyCommand.Execute(input));
        }

        [TestMethod]
        public void CorrectlyExecute_WhenValidDataIsPassed()
        {
            //Arrange
            Mock<IBroker> brockerMock = new Mock<IBroker>();
            Mock<IUser> userMock = new Mock<IUser>();
            brockerMock.Setup(brocker => brocker.Buy("name", 10)).Returns("invoked");
            BuyCommand buyCommand = new BuyCommand(brockerMock.Object);

            IList<string> input = new List<string>();
            input.Add("name");
            input.Add("10");

            //Act 
            string result = buyCommand.Execute(input);

            //Assert
            Assert.AreEqual("invoked", result);
        }
    }
}
