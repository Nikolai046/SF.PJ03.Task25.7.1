namespace SF.PJ03.Task25._7._1.DAL.Entities;

/// <summary>
/// Модель сущности пользователя. Содержит данные о идентификаторе, имени, email и связанных книгах.
/// </summary>
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }

    public ICollection<Book>? Books { get; set; } = [];
}