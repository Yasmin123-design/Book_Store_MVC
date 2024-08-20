using Microsoft.EntityFrameworkCore;

namespace BOOKS_.Models
{
    public class BookContext : DbContext
    {
        
        public BookContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<ReaderBook> ReaderBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I7PU4G3;Database=Library;Trusted_Connection=True;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReaderBook>().HasKey(x => new { x.ReaderId, x.BookId });
        }
    }
}
