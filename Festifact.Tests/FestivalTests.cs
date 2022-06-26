using Festifact.API.Controllers;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Xml.Linq;

namespace Festifact.Tests
{
    public class FestivalTests
    {
        [Fact]
        public void ReturnFestivalById()
        {
            // Arrange
            var id = 12;
            var name = "Avans Live";

            Festival festival;
            festival = new Festival { FestivalId = id, Name = name};

            var mock = new Mock<IFestivalRepository>();
            mock.Setup(x => x.Find(id)).Returns(festival);

            var controller = new FestivalController(mock.Object);
            // Act
            var actual = controller.GetFestival(id);
            var result = (OkObjectResult)actual;
            var festival1 = (Festival)result.Value;

            // Assert
            Assert.IsType<OkObjectResult>(actual);
            Assert.Equal(festival, festival1);
        }

        [Fact]
        public void GetFestivalsReturnsOkResult()
        {
            // Arrange
            IEnumerable<Festival> festival;
            festival = new List<Festival>();

            var mock = new Mock<IFestivalRepository>();
            mock.Setup(x => x.All).Returns(festival);

            var controller = new FestivalController(mock.Object);

            // Act
            var okResult = controller.List() as OkObjectResult;

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }


    }
}