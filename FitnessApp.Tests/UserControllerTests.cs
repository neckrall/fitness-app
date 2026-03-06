using FitnessApp.BL.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FitnessApp.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void RegisterTest() 
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var userGenderName = "Мужской";
            var userBirthdate = new DateTime(2002, 3, 13);
            var userWeight = 68;
            var userHeight = 168;
            var registerController = new UserController(userName);

            // Act
            registerController.Register(userGenderName, userBirthdate, userWeight, userHeight);
            var authorizeController = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, authorizeController.User.Name);
            Assert.AreEqual(userBirthdate, authorizeController.User.BirthDate);
            Assert.AreEqual(userWeight, authorizeController.User.Weight);
            Assert.AreEqual(userHeight, authorizeController.User.Height);
        }
    }
}
