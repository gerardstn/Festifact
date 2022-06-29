using Festifact.API.Models;

namespace Festifact.Tests
{
    public class ShowTests
    {
        [Fact]
        public void ModelStateTest()
        {
            // Assange
            Show s = new Show { FestivalId = 1, ArtistId = 1, Description = "description", EndDate = DateTime.Now, FestivalDay = 0, Image ="https://test.bla.com/bla.png", MovieId = 0, Name = "testshow", RoomReservationId = 1, ShowId = 1, StartDate = DateTime.Now  };

            // Assest
            Assert.IsType<int>(s.FestivalId);
            Assert.IsType<int>(s.ArtistId);
            Assert.IsType<int>(s.MovieId);
            Assert.IsType<int>(s.RoomReservationId);
            Assert.IsType<int>(s.ShowId);
            Assert.IsType<int>(s.FestivalDay);
            Assert.IsType<string>(s.Description);
            Assert.IsType<string>(s.Image);
            Assert.IsType<string>(s.Name);
            Assert.IsType<DateTime>(s.StartDate);
            Assert.IsType<DateTime>(s.EndDate);

        }
    }
}