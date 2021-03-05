using MessageBoardAPI.Models;
using MessageBoardAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardAPI.Tests
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        [TestCategory("Login")]
        public async Task Login_Success()
        {
            // Arrange
            string username = "User 1";
            string password = "Password1";
            var login = new LoginService();

            // Act
            bool status = await login.LoginAsync(username, password);

            // Assert
            Assert.IsTrue(status);
        }

        [TestMethod]
        [TestCategory("Login")]
        public async Task Login_PasswordFailure()
        {
            // Arrange
            string username = "User 1";
            string password = "Password2";
            var login = new LoginService();

            // Act
            bool status = await login.LoginAsync(username, password);

            // Assert
            Assert.IsFalse(status);
        }

        [TestMethod]
        [TestCategory("Login")]
        public async Task Login_UserFailure()
        {
            // Arrange
            string username = "User 2";
            string password = "Password1";
            var login = new LoginService();

            // Act
            bool status = await login.LoginAsync(username, password);

            // Assert
            Assert.IsFalse(status);
        }

        [TestMethod]
        [TestCategory("Messages")]
        public async Task Messages_GetUserMessages_MessageExists()
        {
            // Arrange
            string username = "User 2";
            var message = new MessageService();
            Message testMessage = new Message()
            {
                MessageId = Guid.NewGuid(),
                Name = username,
                MessageText = "Test Message 3",
                CreatedDate = DateTime.Now
            };

            // Act
            var storedMessages = await message.GetUserMessagesAsync(testMessage.Name);
            bool messageExists = storedMessages.Any(x => x.Name == testMessage.Name && x.MessageText == testMessage.MessageText);
            // Assert
            Assert.IsTrue(messageExists);
        }

        [TestMethod]
        [TestCategory("Messages")]
        public async Task Messages_GetUserMessages_MessageDoesNotExists()
        {
            // Arrange
            string username = "User 2";
            var message = new MessageService();
            Message testMessage = new Message()
            {
                MessageId = Guid.NewGuid(),
                Name = username,
                MessageText = "ABC",
                CreatedDate = DateTime.Now
            };

            // Act
            var storedMessages = await message.GetUserMessagesAsync(testMessage.Name);
            bool messageExists = storedMessages.Any(x => x.Name == testMessage.Name && x.MessageText == testMessage.MessageText);

            // Assert
            Assert.IsFalse(messageExists);
        }
    }
}
