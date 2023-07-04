using EntityLayer.Concreat;
using Microsoft.EntityFrameworkCore;

namespace DataAsseccLayer.Concreat
{
    
    public class AppDbContext : DbContext
    {
        public DbSet<About> abouts { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Content> contents { get; set; }
        public DbSet<Heading> headings { get; set; }
        public DbSet<Writer> writers { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<ImageFile> images { get; set; }
        public DbSet<Admin> admins { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder db)
        {
            db.UseNpgsql("Server = localhost; Port = 5432; User Id = postgres; password = dotnet; Database = realmvsnewww;");
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Content>().HasOne(p => p.Heading).WithMany(p => p.Contents).HasForeignKey(p => p.HeadingId);
            model.Entity<Content>().HasOne(p => p.Writer).WithMany(p => p.Contents).HasForeignKey(p => p.WriterId);
            model.Entity<Heading>().HasOne(p => p.Category).WithMany(p => p.Headings).HasForeignKey(p => p.CotegoryId);
            model.Entity<Heading>().HasOne(p => p.Writer).WithMany(p => p.Heading).HasForeignKey(p => p.WriterId);

        }
    }
   
}
