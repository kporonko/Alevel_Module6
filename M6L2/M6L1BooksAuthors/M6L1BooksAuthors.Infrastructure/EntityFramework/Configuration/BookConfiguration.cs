using M6L1BooksAuthors.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace M6L1BooksAuthors.Infrastructure.EntityFramework.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .ToTable("Book")
                .HasKey(x=>x.BookId);
            builder
                .Property(x=>x.BookId)
                .IsRequired()
                .HasColumnName("bookId")
                .HasColumnType("int");
            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("title")
                .HasColumnType("varchar");
            builder
                .Property(x => x.ReleaseYear)
                .HasColumnName("releaseYear")
                .HasColumnType("int");
            builder
                .Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(1000)
                .HasColumnType("varchar");
        }
    }
}
