using GreenCrop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenCrop.Infrastructure.Persistence.Configuration {
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure(EntityTypeBuilder<Customer> builder) {
            builder.HasKey(c => c.Id);
            builder
                .HasOne(a => a.Account)
                .WithOne(c => c.Customer)
                .HasForeignKey<Account>(a => a.CustomerId);              
        }
    }
}
