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
    
    internal partial class ShowImages
    {
        public int Id { get; set; }
        public string ImageType { get; set; }
        public double AspectRatio { get; set; }
        public string FilePath { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Iso6391 { get; set; }
        public double VoteAverage { get; set; }
        public int ShowsId { get; set; }
    }
}
