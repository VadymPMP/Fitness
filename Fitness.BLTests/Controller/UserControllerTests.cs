﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Fitness.BL.Model;

// Arrange

//Act

//Assert

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUSerDataTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            
            var weight = 90.0;
            var height = 190.0;
            var gender = "man";
  
            var controller = new UserController(userName);

            // Act
            controller.SetNewUserData(gender, weight, height);
            var controller2 = new UserController(userName);
            
            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);

        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
           
        }
    }
}