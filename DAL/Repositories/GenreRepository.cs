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
        var genre = _context.Genres.FirstOrDefault(g => g.Name == name);
        if (genre == null)
        {
            genre = new Genre { Name = name };
            _context.Genres.Add(genre);
        }
        return genre;
    }

}