﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin_side.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbmsProject01Entities2 : DbContext
    {
        public dbmsProject01Entities2()
            : base("name=dbmsProject01Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<contact> contacts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_costumerdetails> tbl_costumerdetails { get; set; }
        public virtual DbSet<tbladmin> tbladmins { get; set; }
        public virtual DbSet<tblCategoryDetail> tblCategoryDetails { get; set; }
        public virtual DbSet<tblCustDetail_Cart> tblCustDetail_Cart { get; set; }
        public virtual DbSet<tblorder> tblorders { get; set; }
        public virtual DbSet<tblPayment_Details> tblPayment_Details { get; set; }
        public virtual DbSet<tblProductDetail> tblProductDetails { get; set; }
    }
}
