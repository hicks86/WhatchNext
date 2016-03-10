using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatchNext.DataAccess.Api.Trakt
{
    //public class TraktShowCastDto
    //{
    //    public string character { get; set; }
    //    public TraktPerson person { get; set; }
    //}


    public class Rootobject
    {
        public Cast[] cast { get; set; }
    }

    public class Cast
    {
        public string character { get; set; }
        public Person person { get; set; }
    }

    public class Person
    {
        public string name { get; set; }
        public Ids ids { get; set; }
        public Images images { get; set; }
    }

    public class Ids
    {
        public int trakt { get; set; }
        public string slug { get; set; }
        public string imdb { get; set; }
        public int tmdb { get; set; }
        public int? tvrage { get; set; }
    }

    public class Images
    {
        public Headshot headshot { get; set; }
        public Fanart fanart { get; set; }
    }

    public class Headshot
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



}
