using Book_Shop_Management_API.Models.Entity;
using Book_Shop_Management_API.Models.Entity.EntityConfigration;
using Microsoft.EntityFrameworkCore;

namespace Book_Shop_Management_API.Context
{
    public class BookShoopDBcontext : DbContext
    {
        public BookShoopDBcontext(DbContextOptions dbOptions) : base(dbOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookConfigration());
            modelBuilder.ApplyConfiguration(new FavoriteBookConfigration());
            modelBuilder.ApplyConfiguration(new SubsecriptionConfigration());
            modelBuilder.ApplyConfiguration(new TypeBookConfigration());
            modelBuilder.ApplyConfiguration(new UserConfigration());
            modelBuilder.ApplyConfiguration(new UserSubsecriptionConfigration());
            modelBuilder.ApplyConfiguration(new UserTypeConfigration());

        }


        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<FavoriteBook> FavoriteBoooks { get; set; }
        public virtual DbSet<Subsecription> Subsecriptions { get; set; }
        public virtual DbSet<TypeBook> TypeBooks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSubsecription> UserSubsecriptions { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }


    }
}
