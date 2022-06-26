using Festifact.API.Models;

namespace Festifact.Tests
{
    public class RatingTests
    {
        [Fact]
        public void ModelStateTest()
        {
            // Arrange
            Rating r = new Rating { FestivalId = 1, VisitorId = 1, RatingId = 1, Stars = 5, Message = "message" };

            // Assert
            Assert.IsType<int>(r.FestivalId);
            Assert.IsType<int>(r.VisitorId);
            Assert.IsType<int>(r.RatingId);
            Assert.IsType<int>(r.Stars);
            Assert.IsType<string>(r.Message);
        }
    }
}