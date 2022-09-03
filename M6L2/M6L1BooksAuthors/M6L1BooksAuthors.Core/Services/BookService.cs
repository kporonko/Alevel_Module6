using M6L1BooksAuthors.Core.Interfaces;
using M6L1BooksAuthors.Core.Models;
using M6L1BooksAuthors.Infrastructure.EntityFramework.Data;
using M6L1BooksAuthors.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace M6L1BooksAuthors.Core.Services
{
    public class BookService : IBookService
    {
        //readonly string dir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\M6L1BooksAuthors.Infrastructure\\";
        readonly string dir = "";

        public void AddProduct(BookAdd product)
        {
            try
            {
                Console.WriteLine(dir);
                var books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(dir + "books.json"));
                int Id = new Random().Next(1, 1000);
                Book newBook = new Book { BookId = Id, Description = product.Description, ReleaseYear = product.ReleaseYear, Title = product.Title };
                books.Add(newBook);
                File.WriteAllText(dir + "books.json", JsonConvert.SerializeObject(books));


                var booksAuthors = JsonConvert.DeserializeObject<List<BookAuthor>>(File.ReadAllText(dir + "bookAuthors.json"));
                for (int i = 0; i < product.Authors.Count; i++)
                {
                    booksAuthors.Add(new BookAuthor { BookId = Id, AuthorId = Id, Id = Id, Contribution = product.Authors[i].Contribution, Book = newBook, Author = new Author { AuthorId = Id, Birthday = product.Authors[i].Birthday, FirstName = product.Authors[i].FirstName, LastName = product.Authors[i].LastName } });
                }
                File.WriteAllText(dir + "bookAuthors.json", JsonConvert.SerializeObject(booksAuthors));
            }
            catch (Exception)
            {
            }
        }

        public void DeleteProduct(BookDelete product)
        {
            var books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(dir + "books.json"));
            Book bookToDelete = books.Where(b => b.BookId == product.Id).FirstOrDefault();
            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
            }
            File.WriteAllText(dir + "books.json", JsonConvert.SerializeObject(books));


            var booksAuthors = JsonConvert.DeserializeObject<List<BookAuthor>>(File.ReadAllText(dir + "bookAuthors.json"));
            BookAuthor toDelete = booksAuthors.Where(b => b.BookId == product.Id).FirstOrDefault();
            booksAuthors.Remove(toDelete);

            File.WriteAllText(dir + "bookAuthors.json", JsonConvert.SerializeObject(booksAuthors));
        }

        public Book GetBook(int id)
        {
            try
            {
                var books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(dir + "books.json"));
                var book = books.Where(b => b.BookId == id).FirstOrDefault();
                if (book != null)
                {
                    return book;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Book> GetBooks()
        {
            try
            {
                var model = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(dir + "books.json"));
                if (model != null)
                {
                    return model;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void UpdateProduct(BookPut product)
        {
            var books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(dir + "books.json"));
            Book bookUpd = books.Where(b => b.BookId == product.Id).FirstOrDefault();
            bookUpd.Title = product.Title;
            bookUpd.Description = product.Description;
            File.WriteAllText(dir + "books.json", JsonConvert.SerializeObject(books));
        }


        //public async Task UpdateProductAsync(BookPut product)
        //{
        //    try
        //    {
        //        using (_context)
        //        {
        //            Book book = await _context.Books.Where(x => x.BookId == product.Id).FirstAsync();

        //            if (book != null)
        //            {
        //                book.Title = product.Title;
        //                book.Description = product.Description;
        //                _context.Update(book);
        //            }
        //            _context.SaveChanges();
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task DeleteProductAsync(BookDelete product)
        //{
        //    try
        //    {
        //        using (_context)
        //        {
        //            Book book = await _context.Books.Where(x => x.BookId == product.Id).FirstAsync();
        //            _context.Remove(book);
        //            _context.SaveChanges();
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<Book> GetBookAsync(int id)
        //{
        //    using (_context)
        //    {
        //        try
        //        {
        //            Book book = await _context.Books.Include(u => u.BooksAuthors).ThenInclude(i => i.Author).Where(i => i.BookId == id).FirstOrDefaultAsync();
        //            if (book != null)
        //            {
        //                return book;
        //            }

        //            return null;
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //}

        //public async Task<List<Book>> GetBooksAsync()
        //{
        //    using (_context)
        //    {
        //        try
        //        {
        //            List<Book> books = await _context.Books.Include(u => u.BooksAuthors).ThenInclude(i => i.Author).ToListAsync();
        //            return books;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //}
    }
}
