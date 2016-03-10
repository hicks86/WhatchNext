using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmdbComponent;
using WhatchNext.Biz;
using WhatchNext.DataAccess.Api.Tmdb;

namespace WhatchNext.DataAccess.Api.DalHelpers
{
    internal class TmdbShowsDalHelper : IShowsDalHelper
    {
        public async Task<List<KeyValuePair<string, string>>> GetShowImages(TraktApiId id)
        {
            List<KeyValuePair<string, string>> images = new List<KeyValuePair<string, string>>();

            using (var tmdbApi = new TmdbShowsService())
            {
                if (id.TmdbId != null)
                {
                    var tmdbImageStream = await tmdbApi.GetShowImages(id.TmdbId.Value);

                    var showImages = JsonSerializer.DeserializeSingle<TmdbShowImagesDto>(tmdbImageStream);


                    foreach (var item in showImages.backdrops.Skip(2).Take(10))
                    {
                        images.Add(new KeyValuePair<string, string>("https://image.tmdb.org/t/p/w376/" + item.file_path, "https://image.tmdb.org/t/p/original/" + item.file_path));
                    }

                }
            }

            return images;
        }

        public async Task<string> GetShowVideos(TraktApiId id)
        {
            string trailerUrl = "";

            using (var tmdbApi = new TmdbShowsService())
            {
                if (id.TmdbId != null)
                {
                    var tmdbTrailerStream = await tmdbApi.GetShowTrailers(id.TmdbId.Value);

                    var showTrailers = JsonSerializer.DeserializeSingle<TmdbShowTrailerDto>(tmdbTrailerStream);

                    var trailer = showTrailers.results.Where(x => x.type == "Trailer");


                    if ((trailer.Count() == 1) || ((trailer.Count() > 1)))
                    {
                        trailerUrl = "//www.youtube.com/embed/" + trailer.First().key;
                    }
                    else
                    {
                        if (trailer.Count() > 0)
                        {
                            trailerUrl = "//www.youtube.com/embed/" + showTrailers.results.First().key;
                        }
                        else
                        {
                            trailerUrl = "NoTrailerAvailable";
                        }
                    }
                }
            }

            return trailerUrl;
        }
    }
}
