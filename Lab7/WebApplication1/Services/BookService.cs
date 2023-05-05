using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new List<Book>
    {
        new Book { Id = 1, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960, Genre = "Southern Gothic" },
        new Book { Id = 2, Title = "1984", Author = "George Orwell", Year = 1949, Genre = "Dystopian Fiction" },
        new Book { Id = 3, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Year = 1951, Genre = "Coming-of-Age Fiction" },
        new Book { Id = 4, Title = "Pride and Prejudice", Author = "Jane Austen", Year = 1813, Genre = "Romance" },
        new Book { Id = 5, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925, Genre = "Tragedy" },
        new Book { Id = 6, Title = "Beloved", Author = "Toni Morrison", Year = 1987, Genre = "Magical Realism" },
        new Book { Id = 7, Title = "One Hundred Years of Solitude", Author = "Gabriel Garcia Marquez", Year = 1967, Genre = "Magical Realism" },
        new Book { Id = 8, Title = "Brave New World", Author = "Aldous Huxley", Year = 1932, Genre = "Dystopian Fiction" },
        new Book { Id = 9, Title = "The Picture of Dorian Gray", Author = "Oscar Wilde", Year = 1890, Genre = "Gothic Fiction" },
        new Book { Id = 10, Title = "The Color Purple", Author = "Alice Walker", Year = 1982, Genre = "Epistolary Novel" }
    };

        public async Task<List<Book>> GetBooksAsync()
        {
            return await Task.FromResult(_books);
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await Task.FromResult(result: _books.FirstOrDefault(u => u.Id == id));
        }

        public async Task AddBookAsync(Book book)
        {
            int newId = _books.Any() ? _books.Max(u => u.Id) + 1 : 1;
            book.Id = newId;
            _books.Add(book);
            await Task.CompletedTask;
        }

        public async Task UpdateBookAsync(Book book)
        {
            var existingBook = await GetBookByIdAsync(book.Id);
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Year = book.Year;
            existingBook.Genre = book.Genre;
            await Task.CompletedTask;
        }

        public async Task DeleteBookAsync(Book book)
        {
            _books.Remove(book);
            await Task.CompletedTask;
        }
    }
}
