using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatchNext.DataAccess.Dto
{
    public class PopularShowInformationDto
    {
        public string title { get; set; }
        public int year { get; set; }
        public PopularShowIds ids { get; set; }
    }

    public class PopularShowIds
    {
        public int trakt { get; set; }
        public string slug { get; set; }
        public int tvdb { get; set; }
        public string imdb { get; set; }
        public int tmdb { get; set; }
        public int? tvrage { get; set; }
    }
}
