using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly List<Author> _authors = new List<Author>
    {
        new Author { Id = 1, Name = "J.K.", Surname = "Rowling", BookName = "Harry Potter and the Philosopher's Stone" },
        new Author { Id = 2, Name = "George R.R.", Surname = "Martin", BookName = "A Game of Thrones" },
        new Author { Id = 3, Name = "Agatha", Surname = "Christie", BookName = "Murder on the Orient Express" },
        new Author { Id = 4, Name = "Ernest", Surname = "Hemingway", BookName = "The Old Man and the Sea" },
        new Author { Id = 5, Name = "Harper", Surname = "Lee", BookName = "To Kill a Mockingbird" },
        new Author { Id = 6, Name = "J.R.R.", Surname = "Tolkien", BookName = "The Lord of the Rings" },
        new Author { Id = 7, Name = "Stephen", Surname = "King", BookName = "The Shining" },
        new Author { Id = 8, Name = "Virginia", Surname = "Woolf", BookName = "Mrs Dalloway" },
        new Author { Id = 9, Name = "Jane", Surname = "Austen", BookName = "Pride and Prejudice" },
        new Author { Id = 10, Name = "Gabriel", Surname = "García Márquez", BookName = "One Hundred Years of Solitude" }
    };

        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await Task.FromResult(_authors);
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await Task.FromResult(result: _authors.FirstOrDefault(u => u.Id == id));
        }

        public async Task AddAuthorAsync(Author author)
        {
            int newId = _authors.Any() ? _authors.Max(u => u.Id) + 1 : 1;
            author.Id = newId;
            _authors.Add(author);
            await Task.CompletedTask;
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            var existingAuthor = await GetAuthorByIdAsync(author.Id);
            existingAuthor.Name = author.Name;
            existingAuthor.Surname = author.Surname;
            existingAuthor.BookName = author.BookName;
            await Task.CompletedTask;
        }

        public async Task DeleteAuthorAsync(Author author)
        {
            _authors.Remove(author);
            await Task.CompletedTask;
        }
    }
}
