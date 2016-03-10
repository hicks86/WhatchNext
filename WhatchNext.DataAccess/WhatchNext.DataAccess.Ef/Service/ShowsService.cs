using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatchNext.DataAccess.Ef.CoreModel;
using WhatchNext.DataAccess.Ef.DTO;

namespace WhatchNext.DataAccess.Ef.Service
{
    public class ShowsService 
    {
        private UnitOfWork _uow;
        private bool _disposed;

        public ShowsService(UnitOfWork uow)
        {
            _uow = uow;
        }

        #region Add Show

        public void AddShow(int showId, string showJsonConfiguration, int version = 1)
        {
            bool doesShowAlreadyExist = _uow.Session.ShowDatas.Any(x => x.ShowId == showId 
                                                                    && x.JsonConfiguration == showJsonConfiguration 
                                                                    && x.Version == version);
            if (!doesShowAlreadyExist)
            {
                ShowData show = new ShowData
                {
                    ShowId = showId,
                    JsonConfiguration = showJsonConfiguration,
                    Version = version
                };

                _uow.Session.ShowDatas.Add(show);
            }

        }

        public void AddShow(PopularShowDto popularShow)
        {
            Shows show = GetShowFromIds(popularShow.Ids.trakt, popularShow.Ids.tmdb);

            if (show == null)
            {
                show = new Shows
                {
                    Title = popularShow.Title,
                    Overview = popularShow.Overview,
                    Rating = popularShow.Rating,
                    Slug = popularShow.Ids.slug,
                    TraktApiId = popularShow.Ids.trakt,
                    TvdbApiId = popularShow.Ids.tvdb,
                    ImdbApiId = popularShow.Ids.imdb,
                    TmdbApiId = popularShow.Ids.tmdb,
                    TvRageApiId = popularShow.Ids.tvrage,
                    ShowImages = GetShowImages(popularShow.Images),
                    ShowVideos = GetShowVideos(popularShow.Videos)
                };

                _uow.Session.Shows.Add(show);
            }
            else
            {
                if (IsShowDetailsDifferent(popularShow, show))
                {
                    show.Overview = popularShow.Overview;
                    show.Rating = Math.Round(popularShow.Rating, 3);


                }
            }
        }
        
        private bool IsShowDetailsDifferent(PopularShowDto popularShow, Shows show)
        {

            bool isRatingsDifferent = Math.Round(show.Rating,7) != Math.Round(popularShow.Rating,7);

            bool isOverviewDifferent = String.Equals(show.Overview, popularShow.Overview, StringComparison.OrdinalIgnoreCase);

            return (isOverviewDifferent && isRatingsDifferent);
           
        }

        internal Shows GetShowFromIds(int traktId, int? tmdbId)
        {
            return _uow.Session.Shows
                                .Include("ShowImages")
                                .Include("ShowVideos")
                                .Where(x => x.TraktApiId == traktId && x.TmdbApiId == tmdbId).FirstOrDefault();
        }

        //private List<ShowDetails> GetShowDetails(PopularShowDto item)
        //{
        //    return new List<ShowDetails>
        //    {
        //        new ShowDetails
        //        {
        //            Overview = item.Overview,
        //            Rating = Math.Round(item.Rating, 7),
        //            Poster = item.Poster
        //        }
        //    };
        //}

        private ICollection<ShowVideos> GetShowVideos(List<ShowVideoDto> videosDto)
        {
            List<ShowVideos> videos = new List<ShowVideos>();

            foreach (var item in videosDto)
            {
                videos.Add(new ShowVideos
                {
                    Type = item.VideoApiType,
                    Name = item.Name,
                    Key = item.Key,
                    Site = item.Site,
                    Size = item.Size,
                });

            }

            return videos;

        }

        private ICollection<ShowImages> GetShowImages(List<ShowImagesDto> imagesDto)
        {
            List<ShowImages> images = new List<ShowImages>();

            foreach (var item in imagesDto)
            {
                images.Add(GetShowImage(item));
            }

            return images;
        }

        private ShowImages GetShowImage(ShowImagesDto item)
        {
            return new ShowImages
            {
                ImageType = item.ImageApiType,
                AspectRatio = item.AspectRatio,
                FilePath = item.FilePath,
                Height = item.Height,
                Width = item.Width,
                Iso6391 = item.Iso6391,
                VoteAverage = item.AverageRating,
            };
        }

        #endregion

        

    }
}
