using WhatchNext.DataAccess.Api.Trakt;
using TraktTvComponent;
using WhatchNext.Biz;
using System.Linq;
using System.Threading.Tasks;
using WhatchNext.DataAccess.Api.DalHelpers;

namespace WhatchNext.DataAccess.Api
{
    public class ShowsDal : Csla.Server.ObjectFactory
    {
        private ShowsDalHelper _showsDalHelper;
        
        #region Utility Methods

        private float GetShowRating(TraktShow show, TraktShowsService service)
        {
            var traktRatingData = service.GetShowRating(show.ids.slug);
            var traktRating = JsonSerializer.DeserializeSingle<TraktShowRating>(traktRatingData.Result);

            return traktRating.rating * 10;
        }

        private async Task<ShowDetails> CreateShowDetails(TraktShowInformationDto data, TraktShowsService service)
        {
            var details = new ShowDetails();
            var showsDalHelper = new ShowsDalHelper();
            MarkOld(details);

            var id = new TraktApiId(data.show.ids.trakt, data.show.ids.slug, data.show.ids.tmdb, data.show.ids.imdb);

            LoadProperty(details, ShowDetails.IdProperty, id);
            LoadProperty(details, ShowDetails.TitleProperty, data.show.title);
            LoadProperty(details, ShowDetails.OverviewProperty, data.show.overview);
            LoadProperty(details, ShowDetails.BackdropProperty, data.show.images.fanart.thumb);
            LoadProperty(details, ShowDetails.YearProperty, data.show.year);

            var images = showsDalHelper.GetShowImages(id);

            LoadProperty(details, ShowDetails.ImagesProperty, images);

            var videos = showsDalHelper.GetShowVideos(id);

            LoadProperty(details, ShowDetails.TrailerProperty, videos);

            return details;

        }

       

        private ShowDetails GetTraktShowDetails(int traktId, TraktShowsService traktApi)
        {
            ShowDetails result;

            TraktShowInformationDto deserializedData = GetTraktShowDetailsFromApi(traktId);

            result = CreateShowDetails(deserializedData, traktApi).Result;

            return result;
        }

        private static TraktShowInformationDto GetTraktShowDetailsFromApi(int traktId)
        {
            using (var traktApi = new TraktShowsService())
            {
                var stream = traktApi.GetTraktTvShowDetails(traktId).Result;

                var deserializedData = JsonSerializer.DeserializeList<TraktShowInformationDto>(stream).Single();

                return deserializedData; 
            }
        }

        #endregion

        #region Fetch Popular Shows

        public PopularShowsList Fetch()
        {
            PopularShowsList result = new PopularShowsList();
            SetIsReadOnly(result, false);
            var rlce = result.RaiseListChangedEvents;
            result.RaiseListChangedEvents = false;

            /// Data Acquisition

            using (var traktApi = new TraktShowsService())
            {
                var jsonStream = traktApi.GetPopularShows().Result;

                var deserializedData = JsonSerializer.DeserializeList<TraktPopularShowInformationDto>(jsonStream);

                foreach (var item in deserializedData)
                {
                    var child = CreatePopularShowInfoItem(item, traktApi);

                    result.Add(child.Result);
                }
            }

            result.RaiseListChangedEvents = rlce;
            SetIsReadOnly(result, true);

            return result;
        }

        private async Task<PopularShowInfo> CreatePopularShowInfoItem(TraktPopularShowInformationDto item, TraktShowsService service)
        {
            var child = new PopularShowInfo();

            MarkAsChild(child);
            MarkOld(child);

            var id = new TraktApiId(item.ids.trakt, item.ids.slug, item.ids.tmdb, item.ids.imdb);

            var traktStream = await service.GetTraktTvShowDetails(id.Key);

            var deserializedData = JsonSerializer.DeserializeList<TraktShowInformationDto>(traktStream).Single();

            LoadProperty(child, PopularShowInfo.IdProperty, id);
            LoadProperty(child, PopularShowInfo.TitleProperty, deserializedData.show.title);
            LoadProperty(child, PopularShowInfo.OverviewProperty, deserializedData.show.overview);
            LoadProperty(child, PopularShowInfo.PosterProperty, deserializedData.show.images.fanart.thumb);


            float score = GetShowRating(deserializedData.show, service);

            LoadProperty(child, PopularShowInfo.RatingProperty, score);

            

            return child;
        }
        
        #endregion

        #region Fetch Show Details

        public ShowDetails Fetch(int id)
        {
            ShowDetails result = new ShowDetails();
            SetIsReadOnly(result, false);

            //Data Acquisition
            using (var traktApi = new TraktShowsService())
            {
                result = GetTraktShowDetails(id, traktApi);
            }


            SetIsReadOnly(result, true);

            return result;
        }
        
        #endregion

        public SimilarShowDetailsList Fetch(string slug)
        {
            SimilarShowDetailsList result = new SimilarShowDetailsList();
            SetIsReadOnly(result, false);

            //Data Acquisition
            using (var traktApi = new TraktShowsService())
            {
                var stream = traktApi.GetRelatedShows(slug).Result;

                var similarShowsRaw = JsonSerializer.DeserializeList<TraktRelatedShowDetails>(stream);

                foreach (var item in similarShowsRaw)
                {
                    SimilarShowDetail child = CreateSimilarShowDetail(traktApi, item);

                    result.Add(child);
                }

            }

            return result;
        }

        private string GetTraktSlug(int id)
        {
            using (var traktApi = new TraktShowsService())
            {
                return GetTraktShowDetailsFromApi(id).show.ids.slug; 
            }
        }

        private SimilarShowDetail CreateSimilarShowDetail(TraktShowsService traktApi, TraktRelatedShowDetails item)
        {
            var child = new SimilarShowDetail();

            MarkAsChild(child);
            MarkOld(child);

            var id = new TraktApiId(item.ids.trakt, item.ids.slug, item.ids.tmdb, item.ids.imdb);
            var showDetailsBiz = GetTraktShowDetails(id.Key, traktApi);


            LoadProperty(child, SimilarShowDetail.IdProperty, id);
            LoadProperty(child, SimilarShowDetail.TitleProperty, item.title);
            LoadProperty(child, SimilarShowDetail.OverviewProperty, showDetailsBiz.Overview);
            LoadProperty(child, SimilarShowDetail.PosterProperty, showDetailsBiz.Images.First().Key);
            LoadProperty(child, SimilarShowDetail.ShowDetailsProperty, showDetailsBiz);
            return child;
        }
    }
}
