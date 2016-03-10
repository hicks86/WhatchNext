using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatchNext.DataAccess.Api.Trakt
{
    public class TraktShowSeasonDto
    {
        public int number { get; set; }
        public TraktApiIds ids { get; set; }
        public SeasonImages images { get; set; }
        public Episode[] episodes { get; set; }
        public int? season { get; set; }
        public string title { get; set; }
    }

    public class SeasonImages
    {
        public TraktImage poster { get; set; }
        public TraktThumb thumb { get; set; }
        public TraktImage screenshot { get; set; }
    }

    public class Episode
    {
        public int season { get; set; }
        public int number { get; set; }
        public string title { get; set; }
        public TraktApiIds ids { get; set; }
        public EpisodeImages images { get; set; }
    }
    
    public class EpisodeImages
    {
        public TraktImage screenshot { get; set; }
    }

}
