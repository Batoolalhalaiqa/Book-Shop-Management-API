using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Shop_Management_API.Models.Entity.EntityConfigration
{
    public class UserConfigration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           
            builder.ToTable("User");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.lastName).IsRequired();
            builder.Property(x => x.FirstName).IsUnicode();
            builder.Property(x => x.lastName).IsUnicode();
            builder.Property(x => x.UserId).UseIdentityColumn();
            builder.Property(x => x.Age).HasDefaultValue(18);
            builder.Property(x => x.FirstName).HasMaxLength(30);
            builder.Property(x => x.Specilization).IsRequired(false);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();
            builder.ToTable(x => x.HasCheckConstraint("CH_User_Age", "Age>= 18"));
            builder.ToTable(x => x.HasCheckConstraint("CH_User_Phone", "Phone LIKE '9627________'"));
            builder.ToTable(x => x.HasCheckConstraint("CH_User_Email", "EMAIL LIKE '%@___%.COM'"));
            builder.HasOne<UserType>(x => x.UserType).WithMany("Users");

        }
    }
}
