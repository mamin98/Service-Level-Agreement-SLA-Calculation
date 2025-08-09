using System.Linq.Expressions;

namespace SLA.Application;

public interface IRepository<T>
    where T : class
{
    Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken = default);
    Task<T?> FindAsync(
        Expression<Func<T, bool>> expression,
        CancellationToken cancellationToken = default
    );
}
