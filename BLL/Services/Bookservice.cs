using SF.PJ03.Task25._7._1.DAL.Database.DAL.Repositories;
using SF.PJ03.Task25._7._1.DAL.Database.PLL.Helpers;
using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database.BLL.Services;

public class Bookservice : IDisposable
{
    public int bookId;
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

    public void AddNewBook()
    {
        Console.Clear();
        Console.WriteLine("Меню добавления книги в библиотеку\n");

        Console.WriteLine("Введите название книги:");
        string title = Console.ReadLine();

        Console.WriteLine("Введите авторов книги (через запятую):");
        string[] authors = Console.ReadLine().Split(", ");

        Console.WriteLine("Введите год публикации :");
        int.TryParse(Console.ReadLine(), out int year);

        Console.WriteLine("Введите жанры (через запятую):");
        string[] genres = Console.ReadLine().Split(", ");

        if (string.IsNullOrWhiteSpace(title) || authors.Length == 0 || year <= 0 || genres.Length == 0)
        {
            AlertMessage.Show("Есть некорректно введенные данные, повторите снова");
            Console.ReadKey();
            return;
        }

        var authorsList = new List<Author>();
        foreach (var author in authors)
        {
            authorsList.Add(_authorRepository.CreateAuthor(author));
        }

        var genreList = new List<Genre>();
        foreach (var genre in genres)
        {
            genreList.Add(_genreRepository.CreateGenre(genre));
        }

        var newBook = new Book
        {
            Title = title,
            Year = year,
            Authors = authorsList,
            Genres = genreList,
        };

        if (_bookRepository.BookIsExist(newBook))
        {
            AlertMessage.Show("Книга с такими параметрами уже существует в библиотеке!");
            Console.ReadKey();
            return;
        }

        // Добавляем книгу
        db.Books.Add(newBook);
        db.SaveChanges();

        SuccessMessage.Show("Книга успешно добавлена!");
        Console.ReadKey();
    }

    public void GetAllBooks()
    {
        Console.Clear();
        var books = _bookRepository.GetAllBooks();
        foreach (var book in books)
        {
            var authors = GetAuthors(book);
            var genres = GetGenres(book);

            Console.WriteLine($"№: {book.Id}, Название: {book.Title}, Год: {book.Year}, Автор(ы): {authors}, Жанр(ы): {genres}");
        }
        Console.ReadKey();
    }

    public bool GetBooksById()
    {
        string input;
        do
        {
            Console.Clear();
            Console.Write("Введите Id искомой книги: ");
            input = Console.ReadLine();
        }
        while (!int.TryParse(input, out bookId)); // Повторяем, пока ввод не станет числом

        var book = _bookRepository.GetBooksById(bookId);
        if (book != null)
        {
            var authors = GetAuthors(book);
            var genres = GetGenres(book);

            SuccessMessage.Show($"Книга c Id:{book.Id} найдена:");
            Console.WriteLine($"Название: {book.Title}, Год: {book.Year}, Автор(ы): {authors}, Жанр(ы): {genres}");
        }
        else
        {
            AlertMessage.Show("Книга с таким Id не найдена.");
            Console.ReadKey();
            return false;
        }

        Console.ReadKey();
        return true;
    }

    // Получаем строку жанров через запятую
    public string GetGenres(Book book)
    {
        return book.Genres != null && book.Genres.Any()
             ? string.Join(", ", book.Genres.Select(g => g.Name))
             : "Нет жанров";
    }

    // Получаем строку авторов через запятую
    public string GetAuthors(Book book)
    {
        return book.Authors != null && book.Authors.Any()
            ? string.Join(", ", book.Authors.Select(a => a.Name))
            : "Нет авторов";
    }

    public void DeleteBookById()
    {
        if (GetBooksById())
        {
            AlertMessage.Show("Вы уверены в удалении д/н");
            while (true)
            {
                Console.Write("\r");
                var key = Console.ReadKey().KeyChar;
                if (key == 'д' | key == 'l')
                {
                    _bookRepository.Delete(bookId);
                    db.SaveChanges();
                    AlertMessage.Show("\nКнига удалена из БД");
                    Console.ReadKey();
                    return;
                }

                if (key == 'н' | key == 'y') return;
            }
        }
    }

    public void GetAllBooksByGenre()
    {
        Console.Clear();
        var bookGenres = _genreRepository.GetAll();
        foreach (var currentGenre in bookGenres)
        {
            Console.WriteLine($"\n======{currentGenre.Name}======");
            var bookByGenre = _bookRepository.GetBooksByGenreAndYear(currentGenre.Name, 1, 2100);
            foreach (var book in bookByGenre)
            {
                var authors = GetAuthors(book);
                var genres = GetGenres(book);
                Console.WriteLine($"№: {book.Id}, Название: {book.Title}, Год: {book.Year}, Автор(ы): {authors}, Жанр(ы): {genres}");
            }
        }
        Console.ReadKey();
    }

    public void GetAllBooksByAuthor()
    {
        Console.Clear();
        var bookAuthors = _authorRepository.GetAll();
        foreach (var currentAuthor in bookAuthors)
        {
            Console.WriteLine($"\n======{currentAuthor.Name}======");
            var bookByAuthor = _bookRepository.GetBooksByAuthor(currentAuthor.Name);
            foreach (var book in bookByAuthor)
            {
                var authors = GetAuthors(book);
                var genres = GetGenres(book);
                Console.WriteLine($"№: {book.Id}, Название: {book.Title}, Год: {book.Year}, Автор(ы): {authors}, Жанр(ы): {genres}");
            }
        }
        Console.ReadKey();
    }

    public void GetAllBooksByAlphabet()
    {
        var books = _bookRepository.GetBooksAlphabetically();
        Console.Clear();
        AlertMessage.Show($"Список книг по алфавиту. Кол-во записей: {books.Count()}");
        foreach (var book in books)
        {
            var authors = GetAuthors(book);
            var genres = GetGenres(book);

            Console.WriteLine($"№: {book.Id}, Название: {book.Title}, Год: {book.Year}, Автор(ы): {authors}, Жанр(ы): {genres}");
        }
        Console.ReadKey();
    }

    public void GetAllBooksByYear()
    {
        var books = _bookRepository.GetBooksByDescendingYear();
        Console.Clear();
        AlertMessage.Show($"Список книг по убыванию года.");
        foreach (var book in books)
        {
            var authors = GetAuthors(book);
            var genres = GetGenres(book);

            Console.WriteLine($"№: {book.Id}, Название: {book.Title}, Год: {book.Year}, Автор(ы): {authors}, Жанр(ы): {genres}");
        }
        Console.ReadKey();
    }

    public void Dispose()
    {
        db?.Dispose();
    }
}