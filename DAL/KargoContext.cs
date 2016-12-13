using ProjeKargoWebForms.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjeKargoWebForms.DAL
{
    public class KargoContext : DbContext
    {
        public KargoContext() : base("KargoDB")
        {
            Database.SetInitializer(new KargoInitializer());
        }
        public DbSet<Adres> Adresler { get; set; }
        public DbSet<Durum> Durumlar { get; set; }
        public DbSet<Il> Iller { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<Kargo> Kargolar { get; set; }
        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<KuryeCagir> KuryeCagirlar { get; set; }
        public DbSet<Kuryeci> Kuryeciler { get; set; }
        public DbSet<Sube> Subeler { get; set; }
        public DbSet<Takip> Takipler { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}