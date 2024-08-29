using CycleTracker.Domain.Entity;

namespace CycleTracker.Domain.Contracts.Repositories;

public interface ICycleRepository
{
    Task<Cycle?> ObterPorId(int id);
    void Adicionar(Cycle cycle);
    void Alterar(Cycle cycle);
    void Remover(int id);
}