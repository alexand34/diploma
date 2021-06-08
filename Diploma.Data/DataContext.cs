using System;
using System.Collections.Generic;
using System.Text;
using Diploma.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:diplomaserver635.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=alexander;Password=Bongzilla123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public DbSet<ValuesPerTime> Measurements { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ValuesPerTime>()
                .ToTable("Measurements");

            modelBuilder.Entity<ValuesPerTime>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).ValueGeneratedOnAdd();
            });
        }
        #endregion
    }
}
