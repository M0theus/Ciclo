using System.Linq.Expressions;

namespace CycleTracker.Domain.Contracts.Repositories;

public interface IRepository<T> where T : IEntity
{
    IUnitOfWork UnitOfWork { get; }
    Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate);
    Task<int> Count(Expression<Func<T, bool>> predicate);
    Task<bool> Any(Expression<Func<T, bool>> predicate);
}