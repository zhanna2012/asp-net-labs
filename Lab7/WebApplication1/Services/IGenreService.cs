using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IGenreService
    {
        Task<List<Genre>> GetGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task AddGenreAsync(Genre genre);
        Task UpdateGenreAsync(Genre genre);
        Task DeleteGenreAsync(Genre genre);
    }
}
