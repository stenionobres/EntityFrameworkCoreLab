using System;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreLab.Persistence.Auditing;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay;
using EntityFrameworkCoreLab.Persistence.EntityTypeConfigurations.Ebay;

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
            modelBuilder.ApplyConfiguration(new CustomerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CartTypeConfiguration());
            modelBuilder.Entity<CartProduct>().HasKey(c => new { c.CartId, c.ProductId });
            modelBuilder.Entity<ProductShippingRate>().HasKey(p => new { p.ProductId, p.ShippingRateId });
        }

        public override int SaveChanges()
        {
            ApplyAuditing();
            return base.SaveChanges();
        }

        private void ApplyAuditing()
        {
            foreach (var auditableEntity in ChangeTracker.Entries<Auditable>())
            {
                var currentDate = DateTime.Now;
                string currentUser = "some_id_of_user";

                if (auditableEntity.State == EntityState.Added || auditableEntity.State == EntityState.Modified)
                {
                    auditableEntity.Entity.UpdatedOn = currentDate;
                    auditableEntity.Entity.UpdatedBy = currentUser;

                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreatedOn = currentDate;
                        auditableEntity.Entity.CreatedBy = currentUser;
                    }
                    else
                    {
                        // we also want to make sure that code is not inadvertly
                        // modifying created date and created by columns 
                        auditableEntity.Property(p => p.CreatedOn).IsModified = false;
                        auditableEntity.Property(p => p.CreatedBy).IsModified = false;
                    }
                }

                if (auditableEntity.State == EntityState.Deleted)
                {
                    auditableEntity.State = EntityState.Modified;

                    // we also want to make sure that code is not inadvertly
                    // modifying another columns 

                    foreach (var auditableProperty in auditableEntity.Properties)
                    {
                        auditableProperty.IsModified = false;
                    }

                    auditableEntity.Entity.DeletedOn = currentDate;
                    auditableEntity.Entity.DeletedBy = currentUser;
                    
                    auditableEntity.Property(p => p.DeletedOn).IsModified = true;
                    auditableEntity.Property(p => p.DeletedBy).IsModified = true;
                }
            }
        }

    }
}
