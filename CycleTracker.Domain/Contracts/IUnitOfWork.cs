namespace CycleTracker.Domain.Contracts;

public interface IUnitOfWork
{
    Task<bool> Commit();
}