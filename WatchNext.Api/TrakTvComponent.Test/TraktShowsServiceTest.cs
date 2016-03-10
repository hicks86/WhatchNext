using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraktTvComponent;
using System.Threading.Tasks;

namespace TrakTvComponent.Test
{
    [TestClass]
    public class TraktShowsServiceTest
    {
        [TestMethod]
        public async Task GetShowByImdbId_PassValidImdbShowId_ReturnShowInformation()
        {
            //Arrange
            TraktShowsService service = new TraktShowsService();

            //Act
            var show = await service.GetImdbShowDetails("tt0185906");

            //Assert
            Assert.IsNotNull(show);
            Assert.IsTrue(show.Contains("[{"));
        }


        [TestMethod]
        public async Task GetShowByTraktId_PassValidTraktShowId_ReturnShowInformation()
        {
            //Arrange
            TraktShowsService service = new TraktShowsService();

            //Act
            var shows = await service.GetTraktTvShowDetails(19792);

            //Assert
            Assert.IsNotNull(shows);
            Assert.IsTrue(shows.Contains("[{"));
        }

        [TestMethod]
        public async Task GetShowByTmdbId_PassValidTmdbId_ReturnShowInformation()
        {
            //Arrange
            TraktShowsService service = new TraktShowsService();

            //Act
            var shows = await service.GetTmdbShowDetails(19885);

            //Assert
            Assert.IsNotNull(shows);
            Assert.IsTrue(shows.Contains("[{"));
        }

        [TestMethod]
        public async Task GetPopularShows_PopularShowsFromApi_ReturnPopularShows()
        {
            //Arrange
            TraktShowsService service = new TraktShowsService();

            //Act
            var shows = await service.GetPopularShows();

            //Assert
            Assert.IsNotNull(shows);
            Assert.IsTrue(shows.Contains("game-of-thrones"));

        }

        [TestMethod]
        public async Task GetShowRating_ShowRatingFromApi_ReturnRating()
        {
            //Arrange
            TraktShowsService service = new TraktShowsService();

            //Act
            var rating = await service.GetShowRating("game-of-thrones");

            //Assert
            Assert.IsTrue(rating.Contains("9.3"));
        }

        [TestMethod]
        public async Task GetShowSeasons_SeasonsForShow_ReturnSeasons()
        {
            //Arrange
            TraktShowsService service = new TraktShowsService();

            //Act
            var seasons = await service.GetShowSeasons("game-of-thrones");

            //Assert
            Assert.IsTrue(seasons.Contains(""));
        }

        [TestMethod]
        public async Task GetSeasonDetails_SeasonDetailsFromApi_ReturnSeasonDetails()
        {
            //Arrange
            TraktShowsService service = new TraktShowsService();

            //Act
            var seasons = await service.GetSeasonDetails("game-of-thrones", 1);

            //Assert
            Assert.IsTrue(seasons.Contains(""));
        }

        [TestMethod]
        public async Task GetShowCast_CastDetailsFromApi_ReturnShowDetails()
        {
            //Arrange
            TraktShowsService service = new TraktShowsService();

            //Act
            var cast = await service.GetShowCastDetails("game-of-thrones");

            //Assert
            Assert.IsTrue(cast.Contains("Dinklage"));
        }
    }
}
