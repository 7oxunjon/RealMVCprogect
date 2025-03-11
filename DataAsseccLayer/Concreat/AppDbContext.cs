using EntityLayer.Concreat;
using Microsoft.EntityFrameworkCore;
using RealMVCprogect.Models;
namespace DataAsseccLayer.Concreat
{

    public class AppDbContext : DbContext
    {
        //public DbSet<About> abouts { get; set; }
        //public DbSet<Category> categories { get; set; }
        //public DbSet<Contact> contacts { get; set; }
        //public DbSet<Content> contents { get; set; }
        //public DbSet<Heading> headings { get; set; }
        //public DbSet<Writer> writers { get; set; }
        //public DbSet<Message> messages { get; set; }
        //public DbSet<ImageFile> images { get; set; }
        //public DbSet<Admin> admins { get; set; }
        //public DbSet<Student> students { get; set; }
        public DbSet<News> news {get;set;}
        public DbSet<Users> users {get;set;}
        

        protected override void OnConfiguring(DbContextOptionsBuilder db)
        {
            db.UseSqlServer("Server=26.184.230.143\\SQLEXPRESS;Database=NewsDB1uzsite;Integrated Security=True;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .HasOne(n => n.Users)        // News bitta Users ga tegishli
                .WithMany()                  // Users ko‘p News yozishi mumkin
                .HasForeignKey(n => n.UserId) // Foreign key sifatida UserId ishlatiladi
                .OnDelete(DeleteBehavior.Cascade); // Agar foydalanuvchi o‘chirib tashlansa, barcha yangiliklar ham o‘chadi

            modelBuilder.Entity<Users>()
                .HasKey(u => u.id); // Users jadvalining asosiy kaliti

            // Agar News ichida User bilan aloqani yuklab olishni xohlasangiz:
            modelBuilder.Entity<News>()
                .Navigation(n => n.Users)
                .AutoInclude();
        }
    }
   
}
