namespace SF.PJ03.Task25._7._1.DAL.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }

    public ICollection<Book>? Books { get; set; } = [];
}