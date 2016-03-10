using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatchNext.DataAccess.Api.Trakt
{
    public class ImdbShowAndMovieInformationDto
    {
        public string type { get; set; }
        public object score { get; set; }
        public Show show { get; set; }
        public Movie movie { get; set; }
    }

    #region Show

    public class Show
    {
        public string title { get; set; }
        public string overview { get; set; }
        public int year { get; set; }
        public string status { get; set; }
        public ShowImages images { get; set; }
        public TraktApiIds ids { get; set; }
    }

    public class ShowImages
    {
        public ShowPoster poster { get; set; }
        public ShowFanart fanart { get; set; }
    }

    public class ShowPoster
    {
        public string full { get; set; }
        public string medium { get; set; }
        public string thumb { get; set; }
    }

    public class ShowFanart
    {
        public string full { get; set; }
        public string medium { get; set; }
        public string thumb { get; set; }
    }

    #endregion

    #region Movie

    public class Movie
    {
        public string title { get; set; }
        public string overview { get; set; }
        public int year { get; set; }
        public MovieImages images { get; set; }
        public MovieIds ids { get; set; }
    }

    public class MovieImages
    {
        public MoviePoster poster { get; set; }
        public MovieFanart fanart { get; set; }
    }

    public class MoviePoster
    {
        public string full { get; set; }
        public string medium { get; set; }
        public string thumb { get; set; }
    }

    public class MovieFanart
    {
        public string full { get; set; }
        public string medium { get; set; }
        public string thumb { get; set; }
    }

    public class MovieIds
    {
        public int trakt { get; set; }
        public string slug { get; set; }
        public string imdb { get; set; }
        public int tmdb { get; set; }
    }

    #endregion
}
