﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServices.Models.Database
{
    using global::WebServices.Models.Database;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LifeSalesInfoDbEntities : DbContext
    {
        public LifeSalesInfoDbEntities()
            : base("name=LifeSalesInfoDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LifeSalesInfo> LifeSalesInfos { get; set; }
    }
}
