using CycleTracker.Domain.Entity;

namespace CycleTracker.Domain.Contracts.Repositories;

public interface IRelacionamentoSexualRepository
{
    Task<RelacionamentoSexual?> ObterPorId(int id);
    void Adicionar(RelacionamentoSexual relacionamentoSexual);
    void Excluir(RelacionamentoSexual relacionamentoSexual);
}