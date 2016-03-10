using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraktTvComponent.Shows.Dto
{
    public class TraktShowInformationDto
    {
        public string type { get; set; }
        public object score { get; set; }
        public TraktShow show { get; set; }
    }

    public class TraktShow
    {
        public string title { get; set; }
        public string overview { get; set; }
        public int year { get; set; }
        public string status { get; set; }
        public Images images { get; set; }
        public Ids ids { get; set; }
    }

    public class Images
    {
        public Poster poster { get; set; }
        public Fanart fanart { get; set; }
    }

    public class Poster
    {
        public string full { get; set; }
        public string medium { get; set; }
        public string thumb { get; set; }
    }

    public class Fanart
    {
        public string full { get; set; }
        public string medium { get; set; }
        public string thumb { get; set; }
    }

    public class Ids
    {
        public int trakt { get; set; }
        public string slug { get; set; }
        public int tvdb { get; set; }
        public string imdb { get; set; }
        public int tmdb { get; set; }
        public int tvrage { get; set; }
    }

}
