using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAuthorAsync()
        {
            return await _authorService.GetAuthorsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorByIdAsync(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return author;
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthorAsync([FromBody] Author author)
        {
            if (author == null)
            {
                return BadRequest();
            }
            await _authorService.AddAuthorAsync(author);
            return CreatedAtAction(nameof(GetAuthorByIdAsync), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthorAsync(int id, [FromBody] Author author)
        {
            if (author == null || id != author.Id)
            {
                return BadRequest();
            }
            var existingAuthor = await _authorService.GetAuthorByIdAsync(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }
            await _authorService.UpdateAuthorAsync(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorAsync(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            await _authorService.DeleteAuthorAsync(author);
            return NoContent();
        }
    }
}
