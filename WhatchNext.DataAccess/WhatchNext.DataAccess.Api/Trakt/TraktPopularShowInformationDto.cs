using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatchNext.DataAccess.Api.Trakt
{
    public class TraktPopularShowInformationDto
    {
        public string title { get; set; }
        public int year { get; set; }
        public TraktApiIds ids { get; set; }
    }

 }
