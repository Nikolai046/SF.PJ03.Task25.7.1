using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database.DAL.Repositories;

public class AuthorRepository : Repository<Author>
{
    public AuthorRepository(AppContext context) : base(context)
    {
    }

    public int GetBooksCountByAuthor(int authorId)
    {
        return _context.Books.Count(b => b.Authors.Any(a => a.Id == authorId));
    }

    public Author CreateAuthor(string name)
    {
        // Проверяем сначала сущности, которые уже добавлены в контекст, но не сохранены
        var author = _context.Authors.Local.FirstOrDefault(a => a.Name == name);

        if (author == null)
        {
            // Если в локальном контексте нет, ищем в базе данных
            author = _context.Authors.FirstOrDefault(a => a.Name == name);

            if (author == null)
            {
                // Если в базе данных нет, создаем новую сущность
                author = new Author { Name = name };
                _context.Authors.Add(author);
            }
        }
        return author;
    }
}