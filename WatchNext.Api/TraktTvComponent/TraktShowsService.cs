using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Configuration;

namespace TraktTvComponent
{
    public class TraktShowsService : IDisposable
    {
        private string _apiKey;
        private Uri _baseAddress;
        private bool _disposed;

        protected string PopularShowsResultLimit
        {
            get
            {
                var limit = ConfigurationManager.AppSettings["PopularShowsResultsLimit"];

                if (limit == null)
                {
                    limit = "30";
                }
                return limit;
            }
        }

        public TraktShowsService()
        {
            _baseAddress = new Uri("https://api-v2launch.trakt.tv/");
            _apiKey = "b52641dd9a9e570d2ac986937146c738b48c7e168d860f94684ed3dbd80c4a7c";
            
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _baseAddress = null;
                _apiKey = null;
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }

        #region Get Show Details

        public async Task<string> GetImdbShowDetails(string id)
        {
            string searchQuery = string.Format("search?id_type={0}&id={1}", "imdb", id);

            return await GetShowDetails(searchQuery);
        }

        public async Task<string> GetTraktTvShowDetails(int id)
        {
            string searchQuery = string.Format("search?id_type={0}&id={1}", "trakt-show", id);

            return await GetShowDetails(searchQuery);
        }
        
        public async Task<string> GetPopularShows()
        {
            string limit = PopularShowsResultLimit;

            string searchQuery = string.Format("shows/popular?page={0}&limit={1}", "1", limit);

            return await GetShowDetails(searchQuery);
        }
        
        public async Task<string> GetTmdbShowDetails(int id)
        {
            string searchQuery = string.Format("search?id_type={0}&id={1}", "tmdb", id);

            return await GetShowDetails(searchQuery);            
        }

        public async Task<string> GetShowRating(string traktSlug)
        {
            string searchQuery = string.Format("shows/{0}/ratings", traktSlug);

            return await GetApiData(searchQuery);
        }
        
        public async Task<string> GetRelatedShows(string slug)
        {
            string searchQuery = string.Format("shows/{0}/related", slug);

            return await GetApiData(searchQuery);
        }
        
        #endregion

        #region Get Season Details

        public async Task<string> GetShowSeasons(string traktSlug)
        {
            string searchQuery = string.Format("shows/{0}/seasons?extended=episodes,images", traktSlug);

            return await GetApiData(searchQuery);
        }

        public async Task<string> GetSeasonDetails(string traktSlug, int seasonId)
        {
            string searchQuery = string.Format("shows/{0}/seasons/{1}?extended=images", traktSlug, seasonId);

            return await GetApiData(searchQuery);
        }

        public async Task<string> GetShowCastDetails(string slug)
        {
            string searchQuery = string.Format("shows/{0}/people?extended=images", slug);

            return await GetApiData(searchQuery);
        }

        #endregion

        protected async Task<string> GetShowDetails(string query)
        {
            return await GetApiData(query);
        }

        protected async Task<string> GetApiData(string searchQuery)
        {
            string responseData;

            using (var httpClient = new HttpClient { BaseAddress = _baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("trakt-api-version", "2");

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("trakt-api-key", _apiKey);

                using (var response = await httpClient.GetAsync(searchQuery))
                {
                    responseData = await response.Content.ReadAsStringAsync();
                    var headers = response.Headers; //Doesn't do anything but useful when debugging to check HTTP Headers Values
                }
            }

            return responseData;
        }

    }
}
