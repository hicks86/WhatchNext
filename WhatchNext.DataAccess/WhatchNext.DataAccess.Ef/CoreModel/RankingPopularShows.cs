//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WhatchNext.DataAccess.Ef.CoreModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class RankingPopularShows
    {
        public int Id { get; set; }
        public int PopularShowsDataId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Rating { get; set; }
    
        public virtual ShowData PopularShowsData { get; set; }
    }
}
