using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay;

namespace EntityFrameworkCoreLab.Persistence.EntityTypeConfigurations.Ebay
{
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            var defaultUserId = "some_id_of_user";

            builder.HasIndex(c => c.Cpf).IsUnique();

            builder.Property(c => c.CreatedBy).HasDefaultValue(defaultUserId);
            builder.Property(c => c.CreatedOn).HasDefaultValueSql("getdate()");

            builder.Property(c => c.UpdatedBy).HasDefaultValue(defaultUserId);
            builder.Property(c => c.UpdatedOn).HasDefaultValueSql("getdate()");
        }
    }
}
