using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Fitness.BL.Model;
using System.Linq;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
                //Arrange
                var userName = Guid.NewGuid().ToString();
                var activityName = Guid.NewGuid().ToString();
                var rnd = new Random();
                var userController = new UserController(userName);
                var exercixeController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 50));

                //Act
                exercixeController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

                //Assert
                Assert.AreEqual(activityName, exercixeController.Activities.First().Name);

        }
    }
}