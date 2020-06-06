using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay;

namespace EntityFrameworkCoreLab.Persistence.EntityTypeConfigurations.Ebay
{
    public class AddressTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            var defaultUserId = "some_id_of_user";

            builder.Property(c => c.CreatedBy).HasDefaultValue(defaultUserId);
            builder.Property(c => c.CreatedOn).HasDefaultValueSql("getdate()");

            builder.Property(c => c.UpdatedBy).HasDefaultValue(defaultUserId);
            builder.Property(c => c.UpdatedOn).HasDefaultValueSql("getdate()");
        }
    }
}
