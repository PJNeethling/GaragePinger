using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkBee.Assesment.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkBee.Assesment.Tests
{
    [TestClass]
    public class GarageControllerTests
    {
        //NOTE:
        //Make sure to run the api project seperate in order to run the unit tests.
        private BusinessController _controller;
        public GarageControllerTests()
        {
            _controller = new BusinessController();
        }

        [TestMethod]
        public async Task AuthenticateWithApi()
        {
            await Context.Authenticate("ParkBee", "ParkBee");
        }
        [TestMethod]
        public async Task GetGarageById_UnknownIDPassed_ReturnsNotFoundResult()
        {
            //Arrange
            var random = new Random();
            var invalidID = random.Next(1000, 2000);

            // Act
            await Context.Authenticate("ParkBee", "ParkBee");
            var notFoundResult = await _controller.GetGarageInformation(invalidID);
            // Assert
            Assert.IsNull(notFoundResult);

        }
        [TestMethod]
        public async Task GetGarageById_ExistingIDPassed_ReturnsOkResult()
        {
            // Arrange
            var validID = 2;
            // Act
            await Context.Authenticate("ParkBee", "ParkBee");
            var notFoundResult = await _controller.GetGarageInformation(validID);
            // Assert
            Assert.IsNotNull(notFoundResult);
        }
        [TestMethod]
        public async Task GetGarageById_ExistingIDPassed_ReturnsRightItem()
        {
            // Arrange
            var validID = 2;
            // Act
            await Context.Authenticate("ParkBee", "ParkBee");
            var okResult = await _controller.GetGarageInformation(validID);
            // Assert
            Assert.AreEqual(validID, okResult.ID);
        }
    }
}
