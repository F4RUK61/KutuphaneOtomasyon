﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KutuphaneOtomasyon
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KutuphaneOtomasyonuEntities2 : DbContext
    {
        public KutuphaneOtomasyonuEntities2()
            : base("name=KutuphaneOtomasyonuEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Personeller> Personeller { get; set; }
        public virtual DbSet<Kayitlar> Kayitlar { get; set; }
        public virtual DbSet<Kaynaklar> Kaynaklar { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
