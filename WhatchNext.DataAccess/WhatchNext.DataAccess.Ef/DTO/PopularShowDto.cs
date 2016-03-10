using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatchNext.DataAccess.Ef.DTO
{
    public class PopularShowDto
    {
        public ApiIds Ids { get; set; }
        public List<ShowImagesDto> Images { get;  set; }
        public string Overview { get;  set; }
        public string Poster { get; set; }
        public float Rating { get;  set; }
        public string Title { get;  set; }
        public List<ShowVideoDto> Videos { get;  set; }
    }

    public class ApiIds
    {
        public int trakt { get; set; }
        public string slug { get; set; }
        public int tvdb { get; set; }
        public string imdb { get; set; }
        public int? tmdb { get; set; }
        public int? tvrage { get; set; }
    }

    public class ShowImagesDto
    {
        public float AspectRatio { get;  set; }
        public float AverageRating { get;  set; }
        public string FilePath { get;  set; }
        public int Height { get;  set; }
        public string ImageApiType { get;  set; }
        public string Iso6391 { get;  set; }
        public int Width { get;  set; }
    }

    public class ShowVideoDto
    {
        public string Key { get;  set; }
        public string Name { get;  set; }
        public string Site { get;  set; }
        public int Size { get;  set; }
        public string VideoApiType { get;  set; }
    }
}
