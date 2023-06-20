using FrenetCalculate.Controllers;
using FrenetCalculate.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace FrenetCalculate.Tests
{
    [TestFixture]
    public class FrenetControllerTests
    {

        [Test]
        public void CalculateFreight_InvalidOriginZipCode_ReturnsErrorMessage()
        {
            // Arrange
            var controller = new FrenetController(null, null);
            var originZipCode = "123abc45678";
            var destinationZipCode = "78901234567";

            // Act
            var result = controller.CalculateFreight(originZipCode, destinationZipCode, null, null);

            // Assert
            Assert.Equals("Invalid origin zip code.", result);
        }

        [Test]
        public void CalculateFreight_InvalidDestinationZipCode_ReturnsErrorMessage()
        {
            // Arrange
            var controller = new FrenetController(null, null);
            var originZipCode = "12345678901";
            var destinationZipCode = "789xyz01234";

            // Act
            var result = controller.CalculateFreight(originZipCode, destinationZipCode, null, null);

            // Assert
            Assert.Equals("Invalid destination zip code.", result);
        }

        [Test]
        public void CalculateFreight_ValidZipCodes_ReturnsSuccessMessage()
        {
            // Arrange
            var controller = new FrenetController(null, null);
            var originZipCode = "12345678901";
            var destinationZipCode = "78901234567";

            // Act
            var result = controller.CalculateFreight(originZipCode, destinationZipCode, null, null);

            // Assert
            Assert.Equals("Freight calculation successful.", result);
        }
    }
}
