using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Shop_Management_API.Models.Entity.EntityConfigration
{
    public class UserSubsecriptionConfigration : IEntityTypeConfiguration<UserSubsecription>
    {
        public void Configure(EntityTypeBuilder<UserSubsecription> builder)
        {
            builder.ToTable("UserSubsecription");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SerialNumberSubsecription).IsRequired();
        }
    }
}
