using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OmdbApi
{
    public class OmdbShowsService : IDisposable
    {
        private Uri _baseAddress;
        private bool _disposed;

        #region Constructor/Destructor

        public OmdbShowsService()
        {
            _baseAddress = new Uri("http://www.omdbapi.com/");
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
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        } 

        #endregion

        #region Get Show Details

        public async Task<string> GetImdbShowDetails(string imdbId)
        {
            string searchQuery = string.Format("?i={0}&tomatoes=true", imdbId);

            return await GetShowDetails(searchQuery);
        }

        protected async Task<string> GetShowDetails(string query)
        {
            return await GetApiData(query);
        }

        protected async Task<string> GetApiData(string searchQuery)
        {
            string responseData;

            using (var httpClient = new HttpClient { BaseAddress = _baseAddress })
            {
                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("trakt-api-version", "2");

                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("trakt-api-key", _apiKey);

                using (var response = await httpClient.GetAsync(searchQuery))
                {
                    responseData = await response.Content.ReadAsStringAsync();
                    var headers = response.Headers; //Doesn't do anything but useful when debugging to check HTTP Headers Values
                }
            }

            return responseData;
        } 
        
        #endregion
    }
}
