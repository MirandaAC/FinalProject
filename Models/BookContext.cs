using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books").HasData(
                new Book
                {
                    BookId = 1,
                    Author = "John Doe",
                    Title = "Testing One",
                    Created = DateTime.Now
                },
                new Book
                {
                    BookId = 2,
                    Author = "Jane Doe",
                    Title = "Testing Two",
                    Created = DateTime.Now
                }
                );
        }
    }
}
