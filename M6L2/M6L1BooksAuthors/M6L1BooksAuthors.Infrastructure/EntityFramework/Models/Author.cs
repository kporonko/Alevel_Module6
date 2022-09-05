using M6L1BooksAuthors.Infrastructure.EntityFramework.Models;

namespace M6L1BooksAuthors.Infrastructure.EntityFramework.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }
        public List<BookAuthor> BooksAuthors { get; set; } = new List<BookAuthor>();
    }
}