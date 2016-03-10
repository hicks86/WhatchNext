using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TraktTvComponent;
using WhatchNext.Biz;
using WhatchNext.DataAccess.Api.Trakt;

namespace WhatchNext.DataAccess.Api
{
    public class SeasonsDal : Csla.Server.ObjectFactory
    {
        public ShowSeasonList Fetch(string slug)
        {
            ShowSeasonList result = new ShowSeasonList();
            SetIsReadOnly(result, false);

            //Data Acquisition
            using (var traktApi = new TraktShowsService())
            {
                var stream = traktApi.GetShowSeasons(slug).Result;

                var showSeasonsRaw = JsonSerializer.DeserializeList<TraktShowSeasonDto>(stream);

                foreach (var item in showSeasonsRaw)
                {
                    ShowSeasonInfo child = CreateShowSeason(item);

                    result.Add(child);
                }
            }

            return result;
        }

        private ShowSeasonInfo CreateShowSeason(TraktShowSeasonDto item)
        {
            var child = new ShowSeasonInfo();

            MarkAsChild(child);
            MarkOld(child);

            var id = new TraktApiId(item.ids.trakt, item.ids.slug, item.ids.tmdb, item.ids.imdb);

            LoadProperty(child, ShowSeasonInfo.IdProperty, id);
            LoadProperty(child, ShowSeasonInfo.SeasonNumberProperty, item.number);
            LoadProperty(child, ShowSeasonInfo.SeasonPosterProperty, GetPoster(item));
            LoadProperty(child, ShowSeasonInfo.SeasonTitleProperty, item.title);
            //LoadProperty(child, ShowSeasonInfo.EpisodeListProperty, GetEpisodes(item));

            return child;
        }

        private static string GetPoster(TraktShowSeasonDto item)
        {
            return (item.images != null ? item.images.poster.medium : "");
        }

        private IEnumerable<EpisodeInfo> GetEpisodes(TraktShowSeasonDto item)
        {
            List<EpisodeInfo> listOfEpisodes = new List<EpisodeInfo>();

            if (item.episodes?.Count() > 0)
            {
                foreach (var episode in item.episodes)
                {
                    listOfEpisodes.Add(new EpisodeInfo(episode.number, episode.title, GetSeasonId(episode.ids)));
                } 
            }
            
            return listOfEpisodes;
        }

        private TraktApiId GetSeasonId(TraktApiIds ids)
        {
            var showId = new TraktApiId(ids.trakt, ids.slug, ids.tmdb, ids.imdb);

            return showId;
        }
    }
}
