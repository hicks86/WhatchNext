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
    
    internal partial class MostPopularShows
    {
        public int Id { get; set; }
        public int ShowsId { get; set; }
        public System.DateTime StartDate { get; set; }
        public double Rating { get; set; }
        public int Ranking { get; set; }
        public System.DateTime EndDate { get; set; }
    
        internal virtual Shows Show { get; set; }
    }
}