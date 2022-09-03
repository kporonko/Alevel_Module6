using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using M6L1BooksAuthors.Infrastructure.EntityFramework.Data;
using M6L1BooksAuthors.Infrastructure.EntityFramework.Models;
using M6L1BooksAuthors.Core;
using M6L1BooksAuthors.Core.Interfaces;
using M6L1BooksAuthors.Core.Models;

namespace M6L1BooksAuthors.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("books")]
        public List<Book> GetBooks()
        {
            return _bookService.GetBooks();
        }

        [HttpGet("book/{id}")]
        public Book GetBook(int id)
        {
            return _bookService.GetBook(id);
        }

        [HttpPost("book")]
        public void AddProduct(BookAdd product)
        {
            _bookService.AddProduct(product);
        }

        [HttpPut("book")]
        public void UpdateProduct(BookPut product)
        {
             _bookService.UpdateProduct(product);
        }

        [HttpDelete("book")]
        public void DeleteProduct(BookDelete product)
        {
             _bookService.DeleteProduct(product);
        }
    }
}
