namespace M6L1BooksAuthors.Infrastructure.EntityFramework.Models
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public string Contribution { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}