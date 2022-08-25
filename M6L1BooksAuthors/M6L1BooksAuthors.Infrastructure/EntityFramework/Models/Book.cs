namespace M6L1BooksAuthors.Infrastructure.EntityFramework.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Description { get; set; }
        public List<BookAuthor> BooksAuthors { get; set; } = new List<BookAuthor>();
    }
}
