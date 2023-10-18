using ManageLibrary_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageLibrary_Infra.EntityConfiguration {
    internal class LoanConfiguration : IEntityTypeConfiguration<Loan> {
        public void Configure(EntityTypeBuilder<Loan> builder) {
            builder.ToTable("Loans");

            builder.HasKey(l=>l.Id);

            builder.HasOne(l => l.Book)
                .WithOne(l => l.Loan)
                .HasForeignKey<Loan>(l => l.IdBook);

            builder.HasOne(l => l.Customer)
                .WithMany(l => l.Loans)
                .HasForeignKey(l => l.IdCustomer);
        }
    }
}
