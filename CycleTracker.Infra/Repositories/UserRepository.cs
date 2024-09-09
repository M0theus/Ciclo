using System.Linq.Expressions;
using CycleTracker.Domain.Contracts.Repositories;
using CycleTracker.Domain.Entity;
using CycleTracker.Infra.Abstractions;
using CycleTracker.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CycleTracker.Infra.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    protected readonly ApplicationDbContext Context;

    protected UserRepository(ApplicationDbContext context) : base(context)
    {
        Context = context;
    }

    public async Task<User?> ObterPorId(int id)
    {
        return await Context.Users
            .Include(u => u.Ciclo)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public  void Adicionar(User user)
    {
        Context.Users.Add(user);
    }

    public void Alterar(User user)
    {
        Context.Users.Update(user);
    }

    public void Excluir(User user)
    {
        Context.Users.Remove(user);
    }
}