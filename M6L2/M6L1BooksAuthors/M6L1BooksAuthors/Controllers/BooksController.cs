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
        public async Task<List<Book>> GetBooksAsync()
        {
            return await _bookService.GetBooksAsync();
        }

        [HttpGet("book/{id}")]
        public async Task<Book> GetBookAsync(int id)
        {
            return await _bookService.GetBookAsync(id);
        }

        [HttpPost("book")]
        public void AddProduct(BookAdd product)
        {
            _bookService.AddProduct(product);
        }

        [HttpPut("book")]
        public async Task UpdateProductAsync(BookPut product)
        {
            await _bookService.UpdateProductAsync(product);
        }

        [HttpDelete("book")]
        public async Task DeleteProductAsync(BookDelete product)
        {
            await _bookService.DeleteProductAsync(product);
        }
    }
}
