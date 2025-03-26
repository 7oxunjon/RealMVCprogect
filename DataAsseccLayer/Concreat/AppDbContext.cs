using EntityLayer.Concreat;
using Microsoft.EntityFrameworkCore;


namespace DataAsseccLayer.Concreat
{

    public class AppDbContext : DbContext
    {
  
        public DbSet<Users> users { get; set; }
        public DbSet<News>  news { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder db)
        {
            db.UseSqlServer("Server=26.184.230.143,1433;Database=NewsDB1uzsite;User Id=sa;Password=Formula1;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .HasOne(n => n.Users)           // News bitta Users ga tegishli
                .WithMany(u => u.news)         // Users ko‘p News yozishi mumkin
                .HasForeignKey(n => n.UserId)  // Foreign key sifatida UserId ishlatiladi
                .OnDelete(DeleteBehavior.Cascade); // Foydalanuvchi o‘chirilsa, bog‘langan News ham o‘chadi

            modelBuilder.Entity<Users>()
                .HasKey(u => u.id); // ✅ `id` emas, `Id` bo‘lishi kerak

            // News -> Users avtomatik yuklash
            modelBuilder.Entity<News>()
                .Navigation(n => n.Users)
                .AutoInclude();
        }

    }

}
