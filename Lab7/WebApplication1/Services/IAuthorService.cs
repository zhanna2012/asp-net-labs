using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(Author author);
    }
}
