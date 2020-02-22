using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts
{
    public class AmazonCodeFirstDbContext : DbContext
    {
        private const string ConnectionString = @"Server=192.168.1.14,32771;Database=AmazonCodeFirst;User ID=sa;Password=sqlserver.252707;
                                                  Encrypt=True;Trusted_Connection=True;Connection Timeout=3000;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
