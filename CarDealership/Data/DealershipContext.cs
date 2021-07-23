using CarDealership.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    class DealershipContext:DbContext
    {
        public DealershipContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=CarDealershipDB;Trusted_Connection=True;");
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            modelBuilder.Entity<CarFeature>()
            .HasKey(bc => new { bc.CarId, bc.FeatureId });
       }

        //entities
        public DbSet<Car> Cars { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}

