using M6L1BooksAuthors.Infrastructure.EntityFramework.Configuration;
using M6L1BooksAuthors.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace M6L1BooksAuthors.Infrastructure.EntityFramework.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());

            modelBuilder.Entity<BookAuthor>()
                .HasOne(p => p.Book)
                .WithMany(x => x.BooksAuthors)
                .HasForeignKey(x => x.BookId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(p => p.Author)
                .WithMany(x => x.BooksAuthors)
                .HasForeignKey(x => x.AuthorId);
        }
    }
}
