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
            modelBuilder.Entity<SalesmenHouses>()
                .HasKey(bc => new { bc.SalesmanId, bc.FinanceHouseId });
        }
        //entities
        public DbSet<Car> Cars { get; set; }
        public DbSet<FinanceHouse> FinanceHouses { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<SalesmenHouses> SalesmenHouses { get; set; }
    }
}

