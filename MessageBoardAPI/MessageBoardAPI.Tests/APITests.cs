using MessageBoardAPI.Models;
using MessageBoardAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageBoardAPI.Tests
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        [TestCategory("Login")]
        public void Login_Success()
        {
            // Arrange
            string username = "User 1";
            string password = "Password1";
            var login = new LoginService();

            // Act
            bool status = login.Login(username, password);

            // Assert
            Assert.IsTrue(status);
        }

        [TestMethod]
        [TestCategory("Login")]
        public void Login_PasswordFailure()
        {
            // Arrange
            string username = "User 1";
            string password = "Password2";
            var login = new LoginService();

            // Act
            bool status = login.Login(username, password);

            // Assert
            Assert.IsFalse(status);
        }

        [TestMethod]
        [TestCategory("Login")]
        public void Login_UserFailure()
        {
            // Arrange
            string username = "User 2";
            string password = "Password1";
            var login = new LoginService();

            // Act
            bool status = login.Login(username, password);

            // Assert
            Assert.IsFalse(status);
        }

        [TestMethod]
        [TestCategory("Messages")]
        public void Messages_GetUserMessages_MessageExists()
        {
            // Arrange
            string username = "User 2";
            var message = new MessageService();
            Message testMessage = new Message()
            {
                Id = 20001,
                Name = username,
                MessageText = "Test Message 3",
                CreatedDate = DateTime.Now
            };

            // Act
            var storedMessages = message.GetUserMessages(testMessage.Name);
            bool messageExists = storedMessages.Any(x => x.Name == testMessage.Name && x.MessageText == testMessage.MessageText);
            // Assert
            Assert.IsTrue(messageExists);
        }

        [TestMethod]
        [TestCategory("Messages")]
        public void Messages_GetUserMessages_MessageDoesNotExists()
        {
            // Arrange
            string username = "User 2";
            var message = new MessageService();
            Message testMessage = new Message()
            {
                Id = 20001,
                Name = username,
                MessageText = "ABC",
                CreatedDate = DateTime.Now
            };

            // Act
            var storedMessages = message.GetUserMessages(testMessage.Name);
            bool messageExists = storedMessages.Any(x => x.Name == testMessage.Name && x.MessageText == testMessage.MessageText);
            // Assert
            Assert.IsFalse(messageExists);
        }
    }
}
