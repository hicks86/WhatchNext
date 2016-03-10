using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatchNext.DataAccess.Api.Trakt
{
    public class TraktImage
    {
        public string full { get; set; }
        public string medium { get; set; }
        public string thumb { get; set; }
    }

    public class TraktThumb
    {
        public string full { get; set; }
    }
}
