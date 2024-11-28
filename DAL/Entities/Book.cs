namespace SF.PJ03.Task25._7._1.DAL.Entities;

/// <summary>
/// Конфигурация сущности `Book` для настройки таблицы в базе данных через Entity Framework.
/// </summary>
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public ICollection<Genre> Genres { get; set; }

    public ICollection<Author> Authors { get; set; }

    public int? UserId { get; set; }
    public User? User { get; set; }
}