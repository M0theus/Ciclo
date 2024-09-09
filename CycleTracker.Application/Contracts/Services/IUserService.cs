using CycleTracker.Application.Dto.V1.User;
using CycleTracker.Domain.Entity;

namespace CycleTracker.Application.Contracts.Services;

public interface IUserService
{
    Task<User?> ObterPorId(int id);
    Task<User?> Cadastrar(CadastrarUsuarioDto dto);
    Task<User?> Alterar(int id, AlterarUsuarioDto dto);
}