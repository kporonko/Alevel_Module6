using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using M6L1BooksAuthors.EntityFramework.Data;
using M6L1BooksAuthors.EntityFramework.Models;
using M6L1BooksAuthors.Models;

namespace M6L1BooksAuthors.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BooksController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("books")]
        public async Task<List<Book>> GetBooksAsync()
        {
            using (ApplicationContext context = new ApplicationContextFactory().CreateDbContext(Array.Empty<string>()))
            {
                try
                {
                    List<Book> books = await context.Books.Include(u => u.BooksAuthors).ToListAsync();
                    return books;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        [HttpGet("book/{id}")]
        public async Task<Book> GetBookAsync(int id)
        {
            using (ApplicationContext context = new ApplicationContextFactory().CreateDbContext(Array.Empty<string>()))
            {
                try
                {
                    Book book = await context.Books.Include(u => u.BooksAuthors).Where(i => i.BookId == id).FirstOrDefaultAsync();
                    if (book != null)
                    {
                        return book;
                    }

                    return null;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        [HttpPost("book")]
        public void AddProduct(BookAdd product)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContextFactory().CreateDbContext(Array.Empty<string>()))
                {
                    Book book = new Book { Description = product.Description, ReleaseYear = product.ReleaseYear, Title = product.Title};
                    for (int i = 0; i < product.Authors.Count; i++)
                    {
                        book.BooksAuthors.Add(new BookAuthor {Contribution = product.Authors[i].Contribution, Book = book, Author = new Author { Birthday = product.Authors[i].Birthday, FirstName = product.Authors[i].FirstName, LastName = product.Authors[i].LastName } });
                    }
                    context.Add(book);
                    context.SaveChanges();
                }

            }
            catch (Exception)
            {
            }
        }

        [HttpPut("book")]
        public async Task AddProductAsync(BookPut product)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContextFactory().CreateDbContext(Array.Empty<string>()))
                {
                    Book book = await context.Books.Where(x => x.BookId == product.Id).FirstAsync();

                    if (book != null)
                    {
                        book.Title = product.Title;
                        book.Description = product.Description;
                        context.Update(book);
                    }
                    context.SaveChanges();
                }

            }
            catch (Exception)
            {
            }
        }

        [HttpDelete("book")]
        public async Task DeleteProductAsync(BookDelete product)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContextFactory().CreateDbContext(Array.Empty<string>()))
                {
                    Book book = await context.Books.Where(x => x.BookId == product.Id).FirstAsync();
                    context.Remove(book);
                    context.SaveChanges();
                }

            }
            catch (Exception)
            {
            }
        }
    }
}
