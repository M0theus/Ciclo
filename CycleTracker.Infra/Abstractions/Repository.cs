using System.Linq.Expressions;
using CycleTracker.Domain.Contracts;
using CycleTracker.Domain.Contracts.Repositories;
using CycleTracker.Domain.Entity;
using CycleTracker.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CycleTracker.Infra.Abstractions;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private bool _isDisposed;
    private readonly DbSet<T> _dbSet;
    protected readonly ApplicationDbContext Context;
    
    public IUnitOfWork UnitOfWork => Context;
    
    protected Repository(ApplicationDbContext context)
    {
        Context = context;
        _dbSet = context.Set<T>();
    }
    public async Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AsNoTrackingWithIdentityResolution().Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<int> Count(Expression<Func<T, bool>> predicate) => await _dbSet.CountAsync(predicate);

    public async Task<bool> Any(Expression<Func<T, bool>> predicate) => await _dbSet.AnyAsync(predicate);
}