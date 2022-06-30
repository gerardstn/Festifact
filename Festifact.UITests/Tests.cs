using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Festifact.UITests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void FestivalsAppear()
        {
            app.Screenshot("Main screen Festivals");

            AppResult[] results = app.WaitForElement(c => c.Marked("Blijdorp Festival"));

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void FestivalDetails()
        {
            app.Tap(c => c.Marked("Blijdorp Festival"));
            AppResult[] results = app.WaitForElement(c => c.Marked("Buy Ticket"));

            app.Screenshot("Festival details");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void NavigateToArtist()
        {
            app.Tap(c => c.Marked("Sziget Festival"));
            app.ScrollDownTo("Arctic Monkeys");
            app.Tap(c => c.Marked("Arctic Monkeys"));
            app.Tap(c => c.Marked("Go to artist"));
            AppResult[] results = app.WaitForElement(c => c.Marked("Add Artist to favorites"));

            app.Screenshot("Artist page");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void SearchFestival()
        {
            app.Tap(c => c.Marked("Search Festivals"));
            app.WaitForElement(c => c.Marked("Type"));
            app.Query(c => c.Marked("Type").Invoke("setText", "music"));
            app.Query(c => c.Marked("Genre").Invoke("setText", "tech"));
            app.Query(c => c.Marked("Age").Invoke("setText", "18"));
            app.Query(c => c.Marked("Location").Invoke("setText", "rott"));
            app.Tap(c => c.Marked("8/3/2022"));
            app.TapCoordinates(800, 1100);
            app.TapCoordinates(800, 1700);
            app.Tap(c => c.Marked("Search Festivals"));
            AppResult[] results = app.WaitForElement(c => c.Marked("Blijdorp Festival"));

            app.Screenshot("Search festival");

            Assert.IsTrue(results.Any());

        }


        [Test]
        public void FavoriteShowAddAndRemove()
        {
            app.Tap(c => c.Marked("Login / Register"));
            app.WaitForElement(c => c.Marked("Email:"));
            app.Query(c => c.Marked("example@example.com").Invoke("setText", "john.doe@gmail.com"));
            app.Query(c => c.Marked("password").Invoke("setText", "password"));

            app.Tap(c => c.Marked("Login"));
            app.WaitForElement(c => c.Marked("Account"));

            app.Tap(c => c.Marked("Blijdorp Festival"));
            app.ScrollDownTo("CHAOS IN THE CBD");
            app.Tap(c => c.Marked("CHAOS IN THE CBD"));
            app.ScrollDownTo("Add show to favorites");
            app.Tap(c => c.Marked("Add show to favorites"));
            app.Tap(c => c.Marked("Account"));
            app.Tap(c => c.Marked("Your favorite shows"));
            AppResult[] results = app.WaitForElement(c => c.Marked("CHAOS IN THE CBD"));
            app.Tap(c => c.Marked("Delete"));
            app.WaitForNoElement(c => c.Marked("CHAOS IN THE CBD"));
            app.Screenshot("Favorites");

            Assert.IsTrue(results.Any());

        }
    }
}
