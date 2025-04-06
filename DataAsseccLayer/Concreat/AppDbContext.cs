using EntityLayer.Concreat;
using Microsoft.EntityFrameworkCore;

namespace DataAsseccLayer.Concreat
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Photos> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder db)
        {
            db.UseSqlServer("Server=26.184.230.143,1433;Database=NewsDB1uzsite;User Id=sa;Password=Formula1;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 📌 News -> Users: har bir yangilik bitta userga tegishli
            modelBuilder.Entity<News>()
                .HasOne(n => n.Users) // News bitta Users ga tegishli
                .WithMany(u => u.news) // Users bir nechta News yozishi mumkin
                .HasForeignKey(n => n.UserId) // ForeignKey UserId
                .OnDelete(DeleteBehavior.Cascade); // User o‘chsa, News ham o‘chadi

            // 📌 News -> Phones: har bir yangilikga bir nechta rasm bo‘lishi mumkin
            modelBuilder.Entity<Photos>()
                .HasOne(p => p.News) // Phones bitta News ga tegishli
                .WithMany(n => n.Images) // News bir nechta Phones (rasmlar) saqlashi mumkin
                .HasForeignKey(p => p.NewsId) // ForeignKey NewsId
                .OnDelete(DeleteBehavior.Cascade); // News o‘chsa, rasmlar ham o‘chadi

            // 📌 Users jadvali primary key
            modelBuilder.Entity<Users>()
                .HasKey(u => u.id); // ✅ `id` emas, `Id` bo‘lishi kerak

            // 📌 News -> Users avtomatik yuklash
            modelBuilder.Entity<News>()
                .Navigation(n => n.Users)
                .AutoInclude();
        }
    }
}
