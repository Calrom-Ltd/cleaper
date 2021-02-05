using MessageBoardAPI.Models;
using MessageBoardAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MessageBoardAPI.Tests
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        public void Login_Success()
        {
            // Arrange
            string username = "User1";
            string password = "Password1";
            var login = new LoginService();

            // Act
            bool status = login.Login(username, password);

            // Assert
            Assert.IsTrue(status);
        }

        [TestMethod]
        public void Login_Failure()
        {
            // Arrange
            string username = "User1";
            string password = "Password2";
            var login = new LoginService();

            // Act
            bool status = login.Login(username, password);

            // Assert
            Assert.IsFalse(status);
        }
    }
}
