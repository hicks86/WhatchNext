using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatchNext.DataAccess.Api.Trakt
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
        public TraktShowImages images { get; set; }
        public TraktApiIds ids { get; set; }
    }

    public class TraktShowImages
    {
        public TraktImage poster { get; set; }
        public TraktImage fanart { get; set; }
    }
    
    
    

}
