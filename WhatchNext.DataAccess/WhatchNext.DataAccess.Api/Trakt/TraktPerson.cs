using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatchNext.DataAccess.Api.Trakt
{
    public class TraktPerson
    {
        public string name { get; set; }
        public TraktApiIds ids { get; set; }
        public string biography { get; set; }
        public string birthday { get; set; }
        public object death { get; set; }
        public string birthplace { get; set; }
        public string homepage { get; set; }
    }
}
