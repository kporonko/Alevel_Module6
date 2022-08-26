using M6L1BooksAuthors.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace M6L1BooksAuthors.Infrastructure.EntityFramework.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .ToTable("Author")
                .HasKey(x => x.AuthorId);
            builder
                .Property(x => x.AuthorId)
                .IsRequired()
                .HasColumnName("authorId")
                .HasColumnType("int");
            builder
                .Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("lastName")
                .HasColumnType("varchar");
            builder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("firstName")
                .HasColumnType("varchar");
            builder
                .Property(x => x.Birthday)
                .HasColumnName("birthday")
                .HasColumnType("date");
        }
    }
}