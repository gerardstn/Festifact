using Festifact.API.Models;

namespace Festifact.Tests
{
    public class ArtistTests
    {
        [Fact]
        public void ModelStateTest()
        {
            // Arrange
            Artist a = new Artist { ArtistId = 1, Name = "artist", Image = "https://bla.bla.com/bla.png", CountryOrigin = "london", Description = "description", Genre = "rock", Type = "music" };

            // Assert
            Assert.IsType<int>(a.ArtistId);
            Assert.IsType<string>(a.Name);
            Assert.IsType<string>(a.Image);
            Assert.IsType<string>(a.CountryOrigin);
            Assert.IsType<string>(a.Description);
            Assert.IsType<string>(a.Genre);
            Assert.IsType<string>(a.Type);
        }
    }
}