using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TmdbComponent.Dto;

namespace TmdbComponent
{
    public class TmdbShowsService : IDisposable
    {
        private string _apiKey;
        private Uri _baseAddress;
        private bool _disposed;

        #region Constructors and Destructors

        public TmdbShowsService()
        {
            _baseAddress = new Uri("http://api.themoviedb.org/3/tv/");
            _apiKey = "065b7f1c4c75ab61507674bc8c677bbd";
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

        #endregion

        public async Task<string> GetShowDetails(int id)
        {
            string searchQuery = id.ToString();

            return await GetApiData(searchQuery);
        }

        public async Task<string> GetShowImages(int id)
        {
            string searchQuery = $"{id.ToString()}/images";

            return await GetApiData(searchQuery);
        }

        public async Task<string> GetPopularShows()
        {
            string searchQuery = "popular";

            return await GetApiData(searchQuery);
        }

        public async Task<string> GetShowTrailers(int id)
        {
            string searchQuery = $"{id.ToString()}/videos";

            return await GetApiData(searchQuery);
        }

        protected async Task<string> GetApiData(string query)
        {
            string responseData;

            using (var httpClient = new HttpClient { BaseAddress = _baseAddress })
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string theQuery = string.Format("{0}?api_key={1}", query, _apiKey);

                using (var response = await httpClient.GetAsync(theQuery))
                {
                    responseData = await response.Content.ReadAsStringAsync();
                }
            }

            return responseData;
        }
    }
}