using cet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace cet.DAL
{
    public class cetContext : DbContext
    {
        public DbSet<Etkinlik> Etkinlik { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Slider> Slider { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<cetContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
    
}