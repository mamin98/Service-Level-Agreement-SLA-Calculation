using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SLA.Application;
using SLA.Domain;

namespace SLA.Infrastructure;

public class Repository<T> : IRepository<T>
    where T : BaseEntity
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(e => !e.IsDeleted).AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<T?> FindAsync(
        Expression<Func<T, bool>> expression,
        CancellationToken cancellationToken = default
    )
    {
        return await _dbSet
                .Where(e => !e.IsDeleted)
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken) ?? null;
    }
}
