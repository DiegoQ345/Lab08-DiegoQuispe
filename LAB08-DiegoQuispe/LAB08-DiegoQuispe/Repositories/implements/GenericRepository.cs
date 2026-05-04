using System.Linq.Expressions;
using LAB08_DiegoQuispe.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB08_DiegoQuispe.Repositories.implements;

public class GenericRepository<T> where T : class
{
    protected readonly LinQDBContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(LinQDBContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
        => await _dbSet.FindAsync(id);

    public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => await _dbSet.Where(predicate).ToListAsync();

    public async Task AddAsync(T entity)
        => await _dbSet.AddAsync(entity);

    public void Update(T entity)
        => _dbSet.Update(entity);

    public void Delete(T entity)
        => _dbSet.Remove(entity);
}
