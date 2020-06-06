using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay;
using EntityFrameworkCoreLab.Persistence.EntityTypeConfigurations.Ebay;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts
{
    public class EbayDatabaseFirstDbContext : DbContext
    {
        private const string ConnectionString = @"Server=192.168.1.14,22331;Database=EbayDatabaseFirst;User ID=sa;Password=sqlserver.252707;
                                                  Encrypt=False;Trusted_Connection=False;Connection Timeout=3000;";

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ShippingRate> ShippingRate { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartProduct> CartProduct { get; set; }
        public DbSet<ProductShippingRate> ProductShippingRate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressTypeConfiguration());
            modelBuilder.Entity<Customer>().HasIndex(c => c.Cpf).IsUnique();
            modelBuilder.ApplyConfiguration(new CartTypeConfiguration());
            modelBuilder.Entity<CartProduct>().HasKey(c => new { c.CartId, c.ProductId });
            modelBuilder.Entity<ProductShippingRate>().HasKey(p => new { p.ProductId, p.ShippingRateId });
        }

    }
}
