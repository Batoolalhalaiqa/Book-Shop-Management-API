using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Book_Shop_Management_API.Models.Entity.User;

namespace Book_Shop_Management_API.Models.Entity.EntityConfigration
{
    public class SubsecriptionConfigration : IEntityTypeConfiguration<Subsecription>
    {
        public void Configure(EntityTypeBuilder<Subsecription> builder)
        {
            builder.ToTable("Subsecription");
            builder.HasKey(x => x.SubsecriptionId);
            builder.Property(x => x.SubsecriptionType).IsRequired();
            builder.Property(x => x.SubsecriptionName).HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.DurationDay).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsAvaible).IsRequired().HasDefaultValue(true);
            builder.ToTable(x => x.HasCheckConstraint("CH_DownloadBookAmount", "DownloadBookAmount >=1"));
            builder.Property(x => x.Price).IsRequired().HasDefaultValue(30);
            builder.HasOne<Client>(x => x.Client)
                .WithMany(x => x.Subsecriptions).HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<Employee>(x => x.Employee).WithMany(x => x.Subsecriptions)
                .HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<Admin>(x => x.Admin).WithMany(x => x.Subsecriptions)
                .HasForeignKey(x => x.AdminId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
