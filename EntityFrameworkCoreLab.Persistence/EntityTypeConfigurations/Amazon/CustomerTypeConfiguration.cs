using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCoreLab.Persistence.EntityTypeConfigurations.Amazon
{
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(c => c.Cpf).IsUnique();
        }
    }
}
