using Festifact.API.Models;
using System.Xml.Linq;

namespace Festifact.Tests
{
    public class FavoriteTests
    {
        [Fact]
        public void ModelStateTest()
        {
            // Arrange
            Favorite f = new() { FavoriteId = 11, ArtistId = 0, ShowId = 5, VisitorId = 7 };

            // Assert
            Assert.IsType<int>(f.FavoriteId);
            Assert.IsType<int>(f.VisitorId);
            Assert.IsType<int>(f.ArtistId);
            Assert.IsType<int>(f.ShowId);
        }


    }
}