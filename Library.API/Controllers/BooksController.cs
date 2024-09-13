using Library.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        // GET api/books
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var books = await _booksService.GetAllBooks();
            return Ok(books);
        }

        // GET api/books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            var book = await _booksService.GetBook(id);
            if (book == null)
            {
                return NotFound(); // 404 Not Found if the book is not found
            }
            return Ok(book);
        }

        [HttpGet("isbn/{isbn}")]
        public async Task<ActionResult<Book>> GetBookByISBN(string isbn)
        {
            Console.WriteLine(isbn);
            var book = await _booksService.GetBookByISBN(isbn);
            if (book == null)
            {
                return NotFound(); // 404 Not Found if the book is not found
            }
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public async Task<ActionResult<Guid>> AddBook([FromBody] Book book)
        {
            Console.WriteLine(book.Id);
            if (book == null)
            {
                return BadRequest("Book cannot be null."); // 400 Bad Request if the book is null
            }
            Console.WriteLine(book.Title);
            var id = await _booksService.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = id }, id); // 201 Created with location of the new resource
        }

        // PUT api/books/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(Guid id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("ID mismatch."); // 400 Bad Request if ID in URL does not match ID in body
            }

            var existingBook = await _booksService.GetBook(id);
            if (existingBook == null)
            {
                return NotFound(); // 404 Not Found if the book does not exist
            }

            await _booksService.UpdateBook(book);
            return NoContent(); // 204 No Content indicating success
        }

        // DELETE api/books/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(Guid id)
        {

            var existingBook = await _booksService.GetBook(id);
            if (existingBook == null)
            {
                return NotFound(); // 404 Not Found if the book does not exist
            }

            await _booksService.DeleteBook(id);
            return NoContent(); // 204 No Content indicating success
        }
    }
}