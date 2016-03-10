using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatchNext.Biz;
using Csla;
using System.Threading.Tasks;

namespace WhatchNext.Biz.Test
{
    [TestClass]
    public class BizObjectTests
    {
        [TestInitialize]
        public void Initialize()
        {
           
        }
        
        [TestMethod]
        public async Task PopularShows_PopularShowsAtThisMoment_ReturnsPopularShowsBizObject()
        {
            //Arrange
            PopularShowsList list;

            //Act
            list = await PopularShowsList.GetPopularShowsAsync();

            //Assert
            Assert.IsNotNull(list);
            Assert.IsNotNull(list.AllowEdit);
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public async Task ShowDetails_ProvidedShowId__ReturnShowDetailsBizObject()
        {
            //Arrange
            ShowDetails show;

            //Act
            show = await ShowDetails.GetShowDetailsAsync(19792);

            //Assert
            Assert.IsNotNull(show);
        }

        [TestMethod]
        public async Task SimilarShowDetails_ProvidedShowId_ReturnSimilarShowDetils()
        {
            //Arrange
            SimilarShowDetailsList similar;

            //Act
            similar = await SimilarShowDetailsList.GetSimilarShowDetailsAsync("dexter");

            //Assert
            Assert.IsNotNull(similar);
        }

        [TestMethod]
        public async Task ShowSeasons_ProvidedShowId_ReturnShowSeasonsAndEpisodes()
        {
            //Arrange
            ShowSeasonList seasons;

            //Act
            seasons = await ShowSeasonList.GetShowSeasonsAsync("game-of-thrones");

            //Assert
            Assert.IsNotNull(seasons);
        }

        [TestMethod]
        public async Task ShowRating_ProvidedImdbIdHasTomatoRating_ReturnRatingObject()
        {
            //Arrange
            ShowRatingInfo rating;

            //Act
            rating = await ShowRatingInfo.GetShowRatingAsync(new TraktApiId(0, "breaking-bad", 0, "tt0903747"));

            //Assert
            Assert.IsNotNull(rating);
            Assert.AreEqual(9.5, rating.ImdbRating);
            Assert.AreEqual(95, rating.RottenTomatoRating);
            Assert.IsTrue(rating.CombinedRating > 9.0);

        }

        [TestMethod]
        public async Task ShowRating_ProvidedImdbIdHasNoTomatoRating_ReturnRatingObject()
        {
            //Arrange
            ShowRatingInfo rating;

            //Act
            rating = await ShowRatingInfo.GetShowRatingAsync(new TraktApiId(0, "band-of-brothers", 0, "tt0185906"));

            //Assert
            Assert.IsNotNull(rating);
            Assert.AreEqual(9.60, rating.ImdbRating);
            Assert.AreEqual(0, rating.RottenTomatoRating);
            Assert.IsTrue(rating.CombinedRating > 9.0); 

        }

        
    }
}
