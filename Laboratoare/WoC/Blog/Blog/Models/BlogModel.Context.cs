﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blog.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BlogEntities : DbContext
    {
        public BlogEntities()
            : base("name=BlogEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comentariu> Comentarius { get; set; }
        public virtual DbSet<Postare> Postares { get; set; }
        public virtual DbSet<Poza> Pozas { get; set; }

        public System.Data.Entity.DbSet<Blog.ViewModels.ArticolViewModel> ArticolViewModels { get; set; }
    }
}
