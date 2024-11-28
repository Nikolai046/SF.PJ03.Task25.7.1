using Microsoft.EntityFrameworkCore;
using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database.DAL.Repositories;

public class BookRepository : Repository<Book>
{
    public BookRepository(AppContext context) : base(context)
    {
    }

    public void UpdateBookYear(int bookId, int newYear)
    {
        var book = GetById(bookId);
        if (book != null)
        {
            book.Year = newYear;
        }
    }

    public void AddAuthorToBookByID(int bookId, int authorId)
    {
        var book = GetById(bookId);
        var author = _context.Authors.FirstOrDefault(a => a.Id == authorId);
        if (book != null && author != null && !book.Authors.Contains(author))
        {
            book.Authors.Add(author);
        }
    }

    public void AddGenreToBook(int bookId, int genreId)
    {
        var book = GetById(bookId);
        var genre = _context.Genres.FirstOrDefault(g => g.Id == genreId);
        if (book != null && genre != null && !book.Genres.Contains(genre))
        {
            book.Genres.Add(genre);
        }
    }

    public IEnumerable<Book> GetBooksByGenreAndYear(string genre, int startYear, int endYear)
    {
        _context.ChangeTracker.Clear();
        return _context.Books
            .Where(b => b.Genres.Any(g => g.Name == genre) && b.Year >= startYear && b.Year <= endYear)
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .ToList();
    }

    public bool IsBookAvailable(string title, int authorId)
    {
        return _context.Books.Any(b => b.Title == title && b.Authors.Any(a => a.Id == authorId));
    }

    public Book? GetLatestBook()
    {
        return _context.Books.OrderByDescending(b => b.Year).FirstOrDefault();
    }

    public IEnumerable<Book> GetBooksAlphabetically()
    {
        return _context.Books
            .AsNoTracking()
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .OrderBy(b => b.Title)
            .ToList();
    }

    public IEnumerable<Book> GetAllBooks()
    {
        _context.ChangeTracker.Clear();
        return _context.Books
            .OrderBy(b => b.Id)
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .ToList();
    }

    public Book? GetBooksById(int findId)
    {
        return _context.Books
            .Where(b => b.Id == findId)
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .FirstOrDefault();
    }

    public IEnumerable<Book> GetBooksByAuthor(string author)
    {
        _context.ChangeTracker.Clear();
        return _context.Books
            .AsNoTracking()
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .Where(b => b.Authors.Any(a => a.Name == author))
            .ToList();
    }

    public IEnumerable<Book> GetBooksByDescendingYear()
    {
        return _context.Books
            .AsNoTracking()
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .OrderByDescending(b => b.Year)
            .ToList();
    }

    public bool BookIsExist(Book book)
    {
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book), "Проверяемая книга не может быть null");
        }

        // Проверяем в локальном контексте
        bool existsInLocal = _context.Books.Local.Any(b =>
            string.Equals(b.Title, book.Title, StringComparison.OrdinalIgnoreCase) &&
            b.Year == book.Year &&
            b.Authors.Count == book.Authors.Count &&
            b.Genres.Count == book.Genres.Count
        );

        if (existsInLocal)
        {
            return true;
        }

        // Проверяем в базе данных
        return _context.Books
                   .Where(b =>
                       b.Title == book.Title &&
                       b.Year == book.Year &&
                       b.Authors.Count == book.Authors.Count &&
                       b.Genres.Count == book.Genres.Count
                   )
                   .SelectMany(b => b.Authors.Select(a => a.Name))
                   .Distinct()
                   .ToHashSet()
                   .SetEquals(book.Authors.Select(a => a.Name).ToHashSet()) &&
               _context.Books
                   .Where(b =>
                       b.Title == book.Title &&
                       b.Year == book.Year &&
                       b.Authors.Count == book.Authors.Count &&
                       b.Genres.Count == book.Genres.Count
                   )
                   .SelectMany(b => b.Genres.Select(g => g.Name))
                   .Distinct()
                   .ToHashSet()
                   .SetEquals(book.Genres.Select(g => g.Name).ToHashSet());
    }

    public void ReturnBook(int bookId, int UserId)
    {
        var book = GetById(bookId);
        if (book != null)
            book.UserId = null;
    }
}