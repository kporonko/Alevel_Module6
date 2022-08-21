using M6L1BooksAuthors.EntityFramework.Models;

namespace M6L1BooksAuthors.Models
{
    public class BookAdd
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Description { get; set; }

        public List<AuthorAdd> Authors { get; set; }
    }
}
