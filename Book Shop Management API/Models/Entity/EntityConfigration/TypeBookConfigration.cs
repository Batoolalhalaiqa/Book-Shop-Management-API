using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Shop_Management_API.Models.Entity.EntityConfigration
{
    public class TypeBookConfigration : IEntityTypeConfiguration<TypeBook>
    {
        public void Configure(EntityTypeBuilder<TypeBook> builder)
        {
            builder.ToTable("TypeBook");
            builder.HasKey(x => x.TypeBookId);
            builder.Property(x => x.Name).HasMaxLength(50);

        }
    }
}
