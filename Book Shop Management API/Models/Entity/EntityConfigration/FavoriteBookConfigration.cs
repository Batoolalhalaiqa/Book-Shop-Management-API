using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Shop_Management_API.Models.Entity.EntityConfigration
{
    public class FavoriteBookConfigration : IEntityTypeConfiguration<FavoriteBook>
    {
        public void Configure(EntityTypeBuilder<FavoriteBook> builder)
        {
            builder.ToTable("FavoriteBook");
            builder.HasKey(x => x.FavoriteId);

        }
    }
}
