﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Weather.Models.DataModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class WeatherEntities : DbContext
    {
        public WeatherEntities()
            : base("name=WeatherEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Cache> Cache { get; set; }
    
        public virtual int usp_AddCache(Nullable<double> lat, Nullable<double> lng, string result)
        {
            var latParameter = lat.HasValue ?
                new ObjectParameter("lat", lat) :
                new ObjectParameter("lat", typeof(double));
    
            var lngParameter = lng.HasValue ?
                new ObjectParameter("lng", lng) :
                new ObjectParameter("lng", typeof(double));
    
            var resultParameter = result != null ?
                new ObjectParameter("result", result) :
                new ObjectParameter("result", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AddCache", latParameter, lngParameter, resultParameter);
        }
    
        public virtual ObjectResult<string> usp_GetCache(Nullable<double> lat, Nullable<double> lng)
        {
            var latParameter = lat.HasValue ?
                new ObjectParameter("lat", lat) :
                new ObjectParameter("lat", typeof(double));
    
            var lngParameter = lng.HasValue ?
                new ObjectParameter("lng", lng) :
                new ObjectParameter("lng", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("usp_GetCache", latParameter, lngParameter);
        }
    
        public virtual int usp_UpdateCache(Nullable<double> lat, Nullable<double> lng, string result)
        {
            var latParameter = lat.HasValue ?
                new ObjectParameter("lat", lat) :
                new ObjectParameter("lat", typeof(double));
    
            var lngParameter = lng.HasValue ?
                new ObjectParameter("lng", lng) :
                new ObjectParameter("lng", typeof(double));
    
            var resultParameter = result != null ?
                new ObjectParameter("result", result) :
                new ObjectParameter("result", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_UpdateCache", latParameter, lngParameter, resultParameter);
        }
    }
}
