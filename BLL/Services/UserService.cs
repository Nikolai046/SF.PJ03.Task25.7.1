using SF.PJ03.Task25._7._1.DAL.Database.DAL.Repositories;
using SF.PJ03.Task25._7._1.DAL.Database.PLL.Helpers;
using SF.PJ03.Task25._7._1.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace SF.PJ03.Task25._7._1.DAL.Database.BLL.Services;

public class UserService : IDisposable
{
    private int userId;
    private Bookservice _bookSvc;
    private readonly AppContext db;
    private readonly UserRepository _userRepository;
    private readonly BookRepository _bookRepository;
    private readonly AuthorRepository _authorRepository;
    private readonly GenreRepository _genreRepository;

    public UserService()
    {
        db = new AppContext();
        _bookSvc = new Bookservice();
        _userRepository = new UserRepository(db);
        _bookRepository = new BookRepository(db);
        _authorRepository = new AuthorRepository(db);
        _genreRepository = new GenreRepository(db);
    }

    public void AddNewUser()
    {
        Console.Clear();
        Console.WriteLine("Меню добавления нового пользователя\n");

        Console.WriteLine("Введите ФИО:");
        string userName = Console.ReadLine();

        Console.WriteLine("Введите свой email:");
        string userEmail = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userName) || (!new EmailAddressAttribute().IsValid(userEmail)))
        {
            AlertMessage.Show("Есть некорректно введенные данные, повторите снова");
            Console.ReadKey();
            return;
        }

        var newUser = new User
        {
            Name = userName,
            Email = userEmail
        };

        _userRepository.Add(newUser);
        db.SaveChanges();

        SuccessMessage.Show("Пользователь успешно добавлен");
        Console.ReadKey();
    }

    public void GetAllUsers()
    {
        Console.Clear();
        var users = _userRepository.GetAllUsers();
        foreach (var user in users)
        {
            Console.WriteLine($"№: {user.Id}, ФИО: {user.Name}, email: {user.Email}");
        }

        Console.ReadKey();
    }

    public void Dispose()
    {
        db?.Dispose();
    }

    public bool GetUserById()
    {
        string input;
        do
        {
            Console.Clear();
            Console.Write("Введите Id искомого пользователя: ");
            input = Console.ReadLine();
        } while (!int.TryParse(input, out userId)); // Повторяем, пока ввод не станет числом

        var user = _userRepository.GetById(userId);
        if (user != null)
        {
            SuccessMessage.Show($"Пользователь c Id:{user.Id} найден:");
            Console.WriteLine($"№: {user.Id}, ФИО: {user.Name}, email: {user.Email}");
        }
        else
        {
            AlertMessage.Show("Пользователь с таким Id не найден.");
            Console.ReadKey();
            return false;
        }

        Console.ReadKey();
        return true;
    }

    public void UpdateUserData()
    {
        Console.Clear();
        Console.WriteLine("Введите Id пользователя, данные которого нужно обновить");
        if (!GetUserById())
        {
            return;
        }

        Console.WriteLine("\nВведите новые ФИО:");
        string userName = Console.ReadLine();

        Console.WriteLine("Введите новый email:");
        string userEmail = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userName) || (!new EmailAddressAttribute().IsValid(userEmail)))
        {
            AlertMessage.Show("Есть некорректно введенные данные, повторите снова");
            Console.ReadKey();
            return;
        }
        _userRepository.UpdateUser(userId, userName, userEmail);
        db.SaveChanges();
        SuccessMessage.Show($"Данные пользователя с ID: {userId} успешно обновлены");
        Console.ReadKey();
    }

    public void TakeBook()
    {
        Console.Clear();
        GetUserById();

        //var bookSvc = new Bookservice();
        _bookSvc.GetBooksById();
        var bookId = _bookSvc.bookId;

        if (!_userRepository.IsBookFree(bookId))
        {
            AlertMessage.Show("К сожалению, книга на руках.");
            Console.ReadKey();
            return;
        }
        _userRepository.TakeBook(userId, bookId);
        db.SaveChanges();
        SuccessMessage.Show($"Пользователь с ID: {userId} успешно взял книгу {bookId}");
        Console.ReadKey();
    }

    public bool GetBookOnHand()
    {
        Console.Clear();
        if (!GetUserById())
        {
            return false;
        }
        var booksOnHand = _userRepository.GetBooksOnHand(userId);
        if (booksOnHand != null && booksOnHand.Any())
        {
            Console.WriteLine("\nКниги на руках:\n");
            foreach (var book in booksOnHand)
            {
                var authors = _bookSvc.GetAuthors(book);
                var genres = _bookSvc.GetGenres(book);

                Console.WriteLine($"№: {book.Id}, Название: {book.Title}, Год: {book.Year}, Автор(ы): {authors}, Жанр(ы): {genres}");
            }
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Нет книг на руках.");
            Console.ReadKey();
            return false;
        }

        return true;
    }

    public void ReturnBook()
    {
        if (!GetBookOnHand()) return;
        Console.WriteLine("\nВведите Id книги которую нужно вернуть");
        int.TryParse(Console.ReadLine(), out int idBookToReturn);

        if (!_userRepository.IsBookTakenByUser(userId, idBookToReturn))
        {
            AlertMessage.Show($"Книги с Id: {idBookToReturn} у пользователя нет");
            Console.ReadKey();
            return;
        }
        _bookRepository.ReturnBook(idBookToReturn, userId);
        db.SaveChanges();
        SuccessMessage.Show($"Книга с Id: {idBookToReturn} успешно возвращена");
        Console.ReadKey();
    }
}