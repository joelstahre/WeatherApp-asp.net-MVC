//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Weather.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cache
    {
        public int cacheID { get; set; }
        public double lat { get; set; }
        public string result { get; set; }
        public System.DateTime nextUpdate { get; set; }
        public double lng { get; set; }
    }
}