using Festifact.API.Controllers;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
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

        [Fact]
        public void ReturnFavoriteArtistsForSpecificUser()
        {
            // Arrange
            var visitorId = 1;


            Favorite favorite;
            Favorite favorite1 = new() {ArtistId = 1, FavoriteId = 1, ShowId = 1, VisitorId = 1};
            Favorite favorite2 = new() {ArtistId = 2, FavoriteId = 2, ShowId = 1, VisitorId = 1};


            List<Favorite> favoriteArtists = new List<Favorite>();
            favoriteArtists.Add(favorite1);
            favoriteArtists.Add(favorite2);

            var mock = new Mock<IFavoriteRepository>();
            mock.Setup(x => x.GetFavoriteArtists(visitorId)).Returns((IEnumerable<Favorite>)favoriteArtists);

            var controller = new FavoriteController(mock.Object);
            // Act
            var actual = controller.FavoriteArtist(visitorId);
            var result = (OkObjectResult)actual;
            var favoriteArtistsResult = result.Value;

            // Assert
            Assert.IsType<OkObjectResult>(actual);
            Assert.Equal(favoriteArtists, favoriteArtistsResult);

        }
    }
}
