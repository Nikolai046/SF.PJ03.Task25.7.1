using Microsoft.EntityFrameworkCore;

namespace SF.PJ03.Task25._7._1.DAL.Database.DAL.Repositories;

public abstract class Repository<T> where T : class
{
    protected readonly AppContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(AppContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public T? GetById(int id)
    {
        return _dbSet.FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void AddRange(List<T> entities)
    {
        _dbSet.AddRange(entities);
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }
}