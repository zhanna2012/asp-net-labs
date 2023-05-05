using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class GenreService : IGenreService
    {
        private readonly List<Genre> _genres = new List<Genre>
    {
        new Genre { Id = 1, Name = "Science Fiction" },
        new Genre { Id = 2, Name = "Romance" },
        new Genre { Id = 3, Name = "Mystery" },
        new Genre { Id = 4, Name = "Thriller" },
        new Genre { Id = 5, Name = "Fantasy" },
        new Genre { Id = 6, Name = "Historical Fiction" },
        new Genre { Id = 7, Name = "Horror" },
        new Genre { Id = 8, Name = "Nonfiction" },
        new Genre { Id = 9, Name = "Biography" },
        new Genre { Id = 10, Name = "Self-Help" }
    };

        public async Task<List<Genre>> GetGenresAsync()
        {
            return await Task.FromResult(_genres);
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await Task.FromResult(result: _genres.FirstOrDefault(u => u.Id == id));
        }

        public async Task AddGenreAsync(Genre genre)
        {
            int newId = _genres.Any() ? _genres.Max(u => u.Id) + 1 : 1;
            genre.Id = newId;
            _genres.Add(genre);
            await Task.CompletedTask;
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            var existingGenre = await GetGenreByIdAsync(genre.Id);
            existingGenre.Name = genre.Name;
            await Task.CompletedTask;
        }

        public async Task DeleteGenreAsync(Genre genre)
        {
            _genres.Remove(genre);
            await Task.CompletedTask;
        }
    }
}
