using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Shop_Management_API.Models.Entity.EntityConfigration
{
    public class BookConfigration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(x => x.BookId);
            builder.Property(x => x.BookId).UseIdentityColumn();
            builder.Property(x => x.Author).IsRequired();
            builder.Property(x => x.Author).IsUnicode();
            builder.Property(x=>x.Version).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(150);
            builder.HasIndex(x => x.Quantity).IsUnique();
            builder.ToTable(t => t.HasCheckConstraint("CH_Quantity", "Quantity >=1 "));
            builder.HasOne<TypeBook>(x => x.TypeBook).WithMany("Books");

        }
    }
}
