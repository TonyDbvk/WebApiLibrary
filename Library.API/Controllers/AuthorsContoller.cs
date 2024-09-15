using AutoMapper;
using Library.API.DTOs.AuthorDtos;
using Library.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorsController(IAuthorService authorService,IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAllAuthors()
        {
            var authors = await _authorService.GetAuthors();
            var result = _mapper.Map<List<AuthorReadDto>>(authors);
            return Ok(result);
        }

        // GET: api/authors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(Guid id)
        {
            var author = await _authorService.GetAuthor(id);
            if (author == null)
            {
                return NotFound(); // 404 Not Found если автор не найден
            }
            var result = _mapper.Map<AuthorReadDto>(author);
            return Ok(result);
        }

        // POST: api/authors
        [HttpPost]
        public async Task<ActionResult<Guid>> AddAuthor([FromBody] AuthorCreateDto authorCreateDto)
        {
            if (authorCreateDto == null)
            {
                return BadRequest("Author cannot be null."); // 400 Bad Request, если автор null
            }

            var author = _mapper.Map<Author>(authorCreateDto); // Маппинг DTO в сущность Author
            Console.WriteLine($"Контроллер {author.Id} {author.FirstName}");
            // Допустим, ваш сервис сохраняет сущность в базе данных и возвращает созданный Id
            var id = await _authorService.AddAuthor(author);

            return CreatedAtAction(nameof(GetAuthorById), new { id = id }, id);
        }


        // PUT: api/authors/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(Guid id, [FromBody] Author author)
        {
            if (id != author.Id)
            {
                return BadRequest("ID mismatch."); // 400 Bad Request если ID в URL не совпадает с ID в теле
            }

            var existingAuthor = await _authorService.GetAuthor(id);
            if (existingAuthor == null)
            {
                return NotFound(); // 404 Not Found если автор не существует
            }

            await _authorService.UpdateAuthor(author);
            return NoContent(); // 204 No Content, что указывает на успешное обновление
        }

        // DELETE: api/authors/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(Guid id)
        {
            var existingAuthor = await _authorService.GetAuthor(id);
            if (existingAuthor == null)
            {
                return NotFound(); // 404 Not Found если автор не существует
            }

            await _authorService.DeleteAuthor(id);
            return NoContent(); // 204 No Content, что указывает на успешное удаление
        }
    }
}
