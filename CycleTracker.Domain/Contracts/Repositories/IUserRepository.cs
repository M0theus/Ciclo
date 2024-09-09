using System.Linq.Expressions;
using CycleTracker.Domain.Entity;

namespace CycleTracker.Domain.Contracts.Repositories;

public interface IUserRepository
{
    Task<User?> ObterPorId(int id);
    void Adicionar(User user);
    void Alterar(User user);
    void Excluir(User user);
    Task<User?> FirstOrDefault(Expression<Func<User, bool>> predicate);
    IUnitOfWork UnitOfWork { get; }
}