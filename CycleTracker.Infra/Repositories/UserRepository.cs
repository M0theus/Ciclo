using CycleTracker.Domain.Contracts.Repositories;
using CycleTracker.Domain.Entity;
using CycleTracker.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CycleTracker.Infra.Repositories;

public class UserRepository : IUserRepository
{
    protected readonly ApplicationDbContext Context;

    public UserRepository(ApplicationDbContext context)
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
        throw new NotImplementedException();
    }

    public void Alterar(User user)
    {
        throw new NotImplementedException();
    }

    public void Excluir(int userId)
    {
        throw new NotImplementedException();
    }
}