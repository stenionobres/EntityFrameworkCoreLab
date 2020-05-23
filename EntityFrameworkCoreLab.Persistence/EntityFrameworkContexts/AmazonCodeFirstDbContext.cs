using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityTypeConfigurations.Amazon;
using EntityFrameworkCoreLab.Persistence.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO;

namespace EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts
{
    public class AmazonCodeFirstDbContext : DbContext
    {
        private const string ConnectionString = @"Server=192.168.1.14,22331;Database=AmazonCodeFirst;User ID=sa;Password=sqlserver.252707;
                                                  Encrypt=False;Trusted_Connection=False;Connection Timeout=3000;";

        public static readonly ILoggerFactory LoggerFactoryToConsole = LoggerFactory.Create(builder => builder.AddConsole());
        public static readonly ILoggerFactory LoggerFactoryToFile = new LoggerFactory(new[] { new FileLoggerProvider(writer: new StreamWriter("efcore_log.txt", append: true)) });

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ShippingRate> ShippingRate { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartProduct> CartProduct { get; set; }
        public DbSet<ProductShippingRate> ProductShippingRate { get; set; }
        public DbSet<SalesInsights> SalesInsights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder.UseSqlServer(ConnectionString);
            optionsBuilder.UseLoggerFactory(LoggerFactoryToFile);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerTypeConfiguration());
            modelBuilder.Entity<Cart>().Property(c => c.Id).ValueGeneratedNever();
            modelBuilder.Entity<CartProduct>().HasKey(c => new { c.CartId, c.ProductId });
            modelBuilder.Entity<ProductShippingRate>().HasKey(p => new { p.ProductId, p.ShippingRateId });
            modelBuilder.Entity<SalesInsights>().ToView("SalesInsights", "sales");
        }
    }
}
