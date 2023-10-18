using ManageLibrary_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageLibrary_Infra.EntityConfiguration {
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure(EntityTypeBuilder<Customer> builder) {
            builder.ToTable("Customer");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.CPF)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Phone)
                .HasMaxLength(11)
                .IsRequired();

            builder.HasMany(c=>c.Loans)
                .WithOne(c=>c.Customer)
                .HasForeignKey(c=>c.IdCustomer);           
        }
    }
}
