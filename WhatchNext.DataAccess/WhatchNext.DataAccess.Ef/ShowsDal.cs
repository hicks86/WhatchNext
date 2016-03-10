using System;
using System.Collections.Generic;
using System.Linq;
using WhatchNext.Biz;
using WhatchNext.DataAccess.Ef.Service;
using System.Configuration;

namespace WhatchNext.DataAccess.Ef
{
    public class ShowsDal : Csla.Server.ObjectFactory
    {
        #region Fetch Popular Shows

        public PopularShowsList Fetch()
        {
            PopularShowsList result = new PopularShowsList();
            SetIsReadOnly(result, false);
            var rlce = result.RaiseListChangedEvents;
            result.RaiseListChangedEvents = false;

            /// Data Acquisition
            using (var uow = new UnitOfWork())
            {
                var popularService = new MostPopularShowsService(uow);

                var popularShows = popularService.GetPopularShows();

                foreach (var item in popularShows)
                {
                    var id = GetShowId(item);

                    var showDetails = item.Show;
                    PopularShowInfo child = new PopularShowInfo();
                    LoadProperty(child, PopularShowInfo.IdProperty, id);
                    LoadProperty(child, PopularShowInfo.OverviewProperty, showDetails.Overview);
                    LoadProperty(child, PopularShowInfo.RatingProperty, ShowRatingInfo.GetShowRatingAsync(id).Result);
                    LoadProperty(child, PopularShowInfo.TitleProperty, item.Show.Title);
                    LoadProperty(child, PopularShowInfo.PosterProperty, GetPosterPath(item));
                    LoadProperty(child, PopularShowInfo.QuickGalleryProperty, GetImages(item));
                    //LoadProperty(child, PopularShowInfo.TrailerProperty, GetTrailer(item));
                    LoadProperty(child, PopularShowInfo.SeasonsProperty, ShowSeasonList.GetShowSeasonsAsync(item.Show.Slug).Result);

                    result.Add(child);
                }
            }
            
            result.RaiseListChangedEvents = rlce;
            SetIsReadOnly(result, true);

            return result;
        }

        private static string GetPosterPath(CoreModel.MostPopularShows item)
        {
            string imageLocation = ConfigurationManager.AppSettings["TmdbImageFilePath"];

            if (imageLocation == null)
            {
                imageLocation = "https://image.tmdb.org/t/p/w780/";
            }

            return imageLocation + item.Show.ShowImages.First().FilePath;
        }

        private string GetTrailer(CoreModel.MostPopularShows item)
        {
            return (item.Show.ShowVideos.Count > 0 ? item.Show.ShowVideos.First().Key : "NoTrailerAvailable");
        }

        private IEnumerable<ImageBackdrops> GetImages(CoreModel.MostPopularShows item)
        {
            List<ImageBackdrops> backdrops = new List<ImageBackdrops>();
            
            foreach (var image in item.Show.ShowImages.Skip(2).Take(10))
            {
                backdrops.Add( new ImageBackdrops
                                {
                                    Thumbnail = "https://image.tmdb.org/t/p/w376/" + image.FilePath,
                                    Poster = "https://image.tmdb.org/t/p/original/" + image.FilePath
                                });
            }

            return backdrops;
        }

        private TraktApiId GetShowId(CoreModel.MostPopularShows item)
        {
            var showId = new TraktApiId(item.Show.TraktApiId, item.Show.Slug, item.Show.TmdbApiId, item.Show.ImdbApiId);

            return showId;
        }



        #endregion
    }
}
