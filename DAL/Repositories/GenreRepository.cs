using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database.DAL.Repositories;

public class GenreRepository : Repository<Genre>
{
    public GenreRepository(AppContext context) : base(context)
    {
    }

    public int GetBooksCountByGenre(string genreName)
    {
        return _context.Books.Count(b => b.Genres.Any(g => g.Name == genreName));
    }

    public Genre CreateGenre(string name)
    {
        // Проверяем сначала сущности, которые уже добавлены в контекст, но не сохранены
        var genre = _context.Genres.Local.FirstOrDefault(g => g.Name == name);

        if (genre == null)
        {
            // Если в локальном контексте нет, ищем в базе данных
            genre = _context.Genres.FirstOrDefault(g => g.Name == name);

            if (genre == null)
            {
                // Если в базе данных нет, создаем новую сущность
                genre = new Genre { Name = name };
                _context.Genres.Add(genre);
            }
        }
        return genre;
    }
}