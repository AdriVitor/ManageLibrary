using ManageLibrary_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageLibrary_Infra.EntityConfiguration {
    internal class BookConfiguration : IEntityTypeConfiguration<Book> {
        public void Configure(EntityTypeBuilder<Book> builder) {
            builder.ToTable("Book");

            builder.HasKey(b => b.Id);

            builder.Property(b=>b.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.Author)
                .HasMaxLength(100);

            builder.Property(b => b.AvailableQuantity)
                .IsRequired();
        }
    }
}
