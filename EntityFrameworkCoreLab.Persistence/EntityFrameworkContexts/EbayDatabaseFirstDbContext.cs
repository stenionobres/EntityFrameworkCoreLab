﻿using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts
{
    public class EbayDatabaseFirstDbContext : DbContext
    {
        private const string ConnectionString = @"Server=192.168.1.14,22331;Database=EbayDatabaseFirst;User ID=sa;Password=sqlserver.252707;
                                                  Encrypt=False;Trusted_Connection=False;Connection Timeout=3000;";

        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasIndex(c => c.Cpf).IsUnique();
        }

    }
}
