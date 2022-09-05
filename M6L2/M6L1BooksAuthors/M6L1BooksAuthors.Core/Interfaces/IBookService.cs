using M6L1BooksAuthors.Core.Models;
using M6L1BooksAuthors.Infrastructure.EntityFramework.Models;
using M6L1BooksAuthors.Core.Models;

namespace M6L1BooksAuthors.Core.Interfaces
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        public Book GetBook(int id);
        public void AddProduct(BookAdd product);
        public void UpdateProduct(BookPut product);
        public void DeleteProduct(BookDelete product);

    }

}
