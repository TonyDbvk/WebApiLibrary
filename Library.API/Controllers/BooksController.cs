using AutoMapper;
using Library.API.DTOs.AuthorDtos;
using Library.API.DTOs.BookDtos;
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
        private readonly IMapper _mapper;
        public BooksController(IBooksService booksService,IMapper mapper)
        {
            _booksService = booksService;
            _mapper = mapper;
        }

        // GET api/books
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var books = await _booksService.GetAllBooks();

            var result = _mapper.Map<List<BookReadDto>>(books);
            return Ok(result);
        }

        // GET api/books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            var book = await _booksService.GetBook(id);
            if (book == null)
            {
                return NotFound(); 
            }
            var result = _mapper.Map<BookReadDto>(book);
            return Ok(result);
        }

        [HttpGet("isbn/{isbn}")]
        public async Task<ActionResult<Book>> GetBookByISBN(string isbn)
        {
            Console.WriteLine(isbn);
            var book = await _booksService.GetBookByISBN(isbn);
            if (book == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<BookReadDto>(book);
            return Ok(result);
        }

       
        [HttpPost]
        public async Task<ActionResult<Guid>> AddBook([FromBody] BookCreateDto bookCreateDto)
        {
            if (bookCreateDto == null)
            {
                return BadRequest("Book cannot be null."); 
            }

            var book = _mapper.Map<Book>(bookCreateDto); 
            Console.WriteLine($"Контроллер {book.Id} {book.Title}");
            var id = await _booksService.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = id }, id);
        }

        // PUT api/books/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(Guid id, [FromBody] BookCreateDto bookCreateDto)
        {

            var existingBook = await _booksService.GetBook(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            var book = _mapper.Map<Book>(bookCreateDto);
            book.Id = existingBook.Id;
            await _booksService.UpdateBook(book);
            return NoContent(); 
        }

  
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(Guid id)
        {

            var existingBook = await _booksService.GetBook(id);
            if (existingBook == null)
            {
                return NotFound(); 
            }

            await _booksService.DeleteBook(id);
            return NoContent(); 
        }
    }
}
