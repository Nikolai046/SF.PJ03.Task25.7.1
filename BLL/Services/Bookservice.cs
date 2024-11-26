using SF.PJ03.Task25._7._1.DAL.Database.DAL.Repositories;

namespace SF.PJ03.Task25._7._1.DAL.Database.BLL.Services;

public class Bookservice : IDisposable
{

    private readonly AppContext db;
    private readonly BookRepository _bookRepository;
    private readonly AuthorRepository _authorRepository;
    private readonly GenreRepository _genreRepository;

    public Bookservice()
    {
        db = new AppContext();
        _bookRepository = new BookRepository(db);
        _authorRepository = new AuthorRepository(db);
        _genreRepository = new GenreRepository(db);
    }

    public void GetAllBooks()
    {
        var prn = _bookRepository.GetBooksAlphabetically();
        foreach (var book in prn)
        {
            Console.WriteLine($"№: {book.Id}, Title: {book.Title} Author(s):");
            foreach (var author in book.Authors)
            {
                Console.Write($"{author} ");
            }

            Console.Write($"Genre(s):");

            foreach (var genre in book.Genres)
            {
                Console.Write($"{genre} ");
            }

            Console.ReadKey();
        }
    }
    public void Dispose()
    {
        db?.Dispose();
    }


}
