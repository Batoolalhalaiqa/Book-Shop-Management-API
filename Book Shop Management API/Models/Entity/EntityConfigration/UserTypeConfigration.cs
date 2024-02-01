using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Shop_Management_API.Models.Entity.EntityConfigration
{
    public class UserTypeConfigration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.ToTable("UserType");
            builder.HasKey(x => x.UserTypeID);
            builder.Property(x => x.UserTypeID).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50);
        }


    }
}
