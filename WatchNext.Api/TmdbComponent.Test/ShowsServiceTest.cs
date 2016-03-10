using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TmdbComponent.Test
{
    [TestClass]
    public class TmdbShowsServiceTest
    {
        [TestMethod]
        public async Task GetShowDetailsById_PassValidId_ReturnShowDetails()
        {
            //Arrange
            TmdbShowsService service = new TmdbShowsService();

            //Act
            var shows = await service.GetShowDetails(19885); 

            //Assert
            Assert.IsNotNull(shows);
            Assert.IsTrue(shows.Contains("19885"));
        }

        [TestMethod]
        public async Task GetPopularShows_ValidConnection_ReturnPopularShows()
        {
            //Arrange
            TmdbShowsService service = new TmdbShowsService();

            //Act
            var shows = await service.GetPopularShows();

            //Assert
            Assert.IsNotNull(shows);
        }

        [TestMethod]
        public async Task GetShowImages_PassValidId_ReturnShowImages()
        {
            //Arrange
            TmdbShowsService service = new TmdbShowsService();

            //Act
            var images = await service.GetShowImages(19885);

            //Assert
            Assert.IsNotNull(images);
            Assert.IsTrue(images.Contains("aspect_ratio"));

        }

        [TestMethod]
        public async Task GetShowTrailers_PassValidId_ReturnShowTrailer()
        {
            //Arrange
            TmdbShowsService service = new TmdbShowsService();

            //Act
            var trailers = await service.GetShowTrailers(19885);

            //Assert
            Assert.IsNotNull(trailers);
            Assert.IsTrue(trailers.Contains("key"));

        }

    }
}
