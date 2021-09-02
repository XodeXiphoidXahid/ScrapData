using Microsoft.EntityFrameworkCore;
using StockData.Stock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Stock.Contexts
{
    public class StockDbContext: DbContext, IStockDbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public StockDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
            .HasMany(c => c.StockPrices)
            .WithOne(s => s.Company);
            
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
    }
}
