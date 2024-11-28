namespace SF.PJ03.Task25._7._1.DAL.Entities;

/// <summary>
/// Модель сущности автора. Содержит идентификатор, имя и связанные книги.
/// </summary>
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Book> Books { get; set; } = [];
}