﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WorkEntities : DbContext
    {
        public WorkEntities()
            : base("name=WorkEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CATEGORy> CATEGORIES { get; set; }
        public DbSet<SUBCATEGORY> SUBCATEGORies { get; set; }
        public DbSet<tblCustomer> tblCustomers { get; set; }
        public DbSet<tblMechanic> tblMechanics { get; set; }
    }
}
