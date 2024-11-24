namespace SF.PJ03.Task25._7._1.DAL.Entities;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Book> Books { get; set; } = [];
}
