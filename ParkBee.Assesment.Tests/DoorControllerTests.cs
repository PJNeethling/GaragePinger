using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkBee.Assesment.Framework;
using ParkBee.Assesment.Framework.Domain;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkBee.Assesment.Tests
{
    [TestClass]
    public class DoorControllerTests
    {
        //NOTE:
        //Make sure to run the api project seperate in order to run the unit tests.
        private BusinessController _controller;
        public DoorControllerTests()
        {
            _controller = new BusinessController();
        }

        [TestMethod]
        public async Task AuthenticateWithApi()
        {
            await Context.Authenticate("ParkBee", "ParkBee");
        }
        [TestMethod]
        public async Task PingDoorByID_UnknownIP_ReturnsOfflineStatus()
        {
            //Arrange
            var random = new Random();
            var invalidID = random.Next(100, 600);

            // Act
            await Context.Authenticate("ParkBee", "ParkBee");
            var notFoundResult = await _controller.PingDoor(invalidID);
            // Assert
            Assert.AreEqual(PingStatuses.UnSuccessful, notFoundResult.Status);

        }
        [TestMethod]
        public async Task PingDoorByID_ValidIP_ReturnsOnlineStatus()
        {
            // Arrange
            var validID = 1;
            // Act
            await Context.Authenticate("ParkBee", "ParkBee");
            var notFoundResult = await _controller.PingDoor(validID);
            // Assert
            Assert.AreEqual(PingStatuses.Successful, notFoundResult.Status);
        }
    }
}
