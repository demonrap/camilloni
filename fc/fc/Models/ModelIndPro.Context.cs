﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fc.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class indproEntities : DbContext
    {
        public indproEntities()
            : base("name=indproEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ma_articoli_img> ma_articoli_img { get; set; }
        public virtual DbSet<mc_cat_merc> mc_cat_merc { get; set; }
        public virtual DbSet<ma_articoli_view> ma_articoli_view { get; set; }
        public virtual DbSet<ma_articoli> ma_articoli { get; set; }
        public virtual DbSet<ma_articoli_richieste> ma_articoli_richieste { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<sy_social> sy_social { get; set; }
        public virtual DbSet<sy_config> sy_config { get; set; }
    }
}