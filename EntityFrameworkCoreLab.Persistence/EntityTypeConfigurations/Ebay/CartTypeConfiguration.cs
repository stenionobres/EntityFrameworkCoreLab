using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCoreLab.Persistence.EntityTypeConfigurations.Ebay
{
    public class CartTypeConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedNever();
        }
    }
}
