using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooksAsync()
        {
            return await _bookService.GetBooksAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookByIdAsync(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            await _bookService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookByIdAsync), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookAsync(int id, [FromBody] Book book)
        {
            if (book == null || id != book.Id)
            {
                return BadRequest();
            }
            var existingBook = await _bookService.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            await _bookService.UpdateBookAsync(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookService.DeleteBookAsync(book);
            return NoContent();
        }
    }
}
