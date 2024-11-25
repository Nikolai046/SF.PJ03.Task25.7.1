using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database.DAL.Repositories;

public class UserRepository : Repository<User>
{
    public UserRepository(AppContext context) : base(context) { }

    public void UpdateUserName(int userId, string newName)
    {
        var user = GetById(userId);
        if (user != null)
        {
            user.Name = newName;
            //  _context.SaveChanges();
        }
    }

    public void TakeBook(int userId, int bookId)
    {
        var user = GetById(userId);
        var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
        if (user != null && book != null && book.UserId == null)
        {
            book.UserId = userId;
            //  _context.SaveChanges();
        }
    }

    public bool IsBookTakenByUser(int userId, int bookId)
    {
        return _context.Books.Any(b => b.Id == bookId && b.UserId == userId);
    }

    public int GetBooksCountOnHand(int userId)
    {
        return _context.Books.Count(b => b.UserId == userId);
    }
}