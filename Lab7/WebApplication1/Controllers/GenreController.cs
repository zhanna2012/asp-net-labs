using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> GetGenresAsync()
        {
            return await _genreService.GetGenresAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenreByIdAsync(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return genre;
        }

        [HttpPost]
        public async Task<IActionResult> AddGenreAsync([FromBody] Genre genre)
        {
            if (genre == null)
            {
                return BadRequest();
            }
            await _genreService.AddGenreAsync(genre);
            return CreatedAtAction(nameof(GetGenreByIdAsync), new { id = genre.Id }, genre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenreAsync(int id, [FromBody] Genre genre)
        {
            if (genre == null || id != genre.Id)
            {
                return BadRequest();
            }
            var existingGenre = await _genreService.GetGenreByIdAsync(id);
            if (existingGenre == null)
            {
                return NotFound();
            }
            await _genreService.UpdateGenreAsync(genre);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreAsync(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            await _genreService.DeleteGenreAsync(genre);
            return NoContent();
        }
    }
}
