using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database.DAL.Repositories;

public class BookRepository : Repository<Book>
{
    public BookRepository(AppContext context) : base(context) { }

    public void UpdateBookYear(int bookId, int newYear)
    {
        var book = GetById(bookId);
        if (book != null)
        {
            book.Year = newYear;
            // _context.SaveChanges();
        }
    }

    public void AddAuthorToBookByID(int bookId, int authorId)
    {
        var book = GetById(bookId);
        var author = _context.Authors.FirstOrDefault(a => a.Id == authorId);
        if (book != null && author != null && !book.Authors.Contains(author))
        {
            book.Authors.Add(author);
            // _context.SaveChanges();
        }
    }

    public void AddGenreToBook(int bookId, int genreId)
    {
        var book = GetById(bookId);
        var genre = _context.Genres.FirstOrDefault(g => g.Id == genreId);
        if (book != null && genre != null && !book.Genres.Contains(genre))
        {
            book.Genres.Add(genre);
            //_context.SaveChanges();
        }
    }





    public IEnumerable<Book> GetBooksByGenreAndYear(string genre, int startYear, int endYear)
    {
        return _context.Books
            .Where(b => b.Genres.Any(g => g.Name == genre) && b.Year >= startYear && b.Year <= endYear)
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
        return _context.Books.OrderBy(b => b.Title).ToList();
    }

    public IEnumerable<Book> GetBooksByDescendingYear()
    {
        return _context.Books.OrderByDescending(b => b.Year).ToList();
    }
}