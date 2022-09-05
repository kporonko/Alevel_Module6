using M6L1BooksAuthors.Core.Models;
using M6L1BooksAuthors.Infrastructure.EntityFramework.Models;
using M6L1BooksAuthors.Core.Models;

namespace M6L1BooksAuthors.Core.Interfaces
{
    public interface IBookService
    {
        public Task<List<Book>> GetBooksAsync();
        public Task<Book> GetBookAsync(int id);
        public void AddProduct(BookAdd product);
        public Task UpdateProductAsync(BookPut product);
        public Task DeleteProductAsync(BookDelete product);

    }

}
