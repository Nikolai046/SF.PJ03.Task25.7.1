using Microsoft.EntityFrameworkCore;
using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database.DAL.Repositories;

public class UserRepository : Repository<User>
{
    public UserRepository(AppContext context) : base(context)
    {
    }

    public void UpdateUser(int userId, string newName, string email)
    {
        var user = GetById(userId);
        if (user != null)
        {
            user.Name = newName;
            user.Email = email;
        }
    }

    public void TakeBook(int userId, int bookId)
    {
        var user = GetById(userId);
        var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
        if (user != null && book != null && book.UserId == null)
        {
            book.UserId = userId;
        }
    }

    public bool IsBookTakenByUser(int userId, int bookId)
    {
        return _context.Books.Any(b => b.Id == bookId && b.UserId == userId);
    }

    public bool IsBookFree(int bookId) => _context.Books.Any(b => b.Id == bookId && b.UserId == null);

    public int GetBooksCountOnHand(int userId)
    {
        return _context.Books.Count(b => b.UserId == userId);
    }

    public IEnumerable<Book> GetBooksOnHand(int userId)
    {
        _context.ChangeTracker.Clear();
        return _context.Books
            .Where(b => b.UserId == userId)
            .OrderBy(b => b.Id)
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .ToList();
    }

    public IEnumerable<User> GetAllUsers()
    {
        _context.ChangeTracker.Clear();
        return _context.Users
            .OrderBy(u => u.Id)
            .ToList();
    }
}