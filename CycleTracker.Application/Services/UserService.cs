using AutoMapper;
using CycleTracker.Application.Contracts.Services;
using CycleTracker.Application.Dto.V1.User;
using CycleTracker.Application.Notifications;
using CycleTracker.Domain.Contracts.Repositories;
using CycleTracker.Domain.Entity;
using Microsoft.AspNetCore.Identity;

namespace CycleTracker.Application.Services;

public class UserService : BaseService, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User?> _passwordHasher;
    
    public UserService(IMapper mapper, INotificator notificator, IUserRepository userRepository, IPasswordHasher<User?> passwordHasher) : base(mapper, notificator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public Task<User?> ObterPorId(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> Cadastrar(CadastrarUsuarioDto dto)
    {
        var usuario = Mapper.Map<User>(dto);
        if (!await Validar(usuario))
        {
            return null;
        }

       

        var senha = Guid.NewGuid().ToString();
        usuario.Senha = _passwordHasher.HashPassword(usuario, senha);
        _userRepository.Adicionar(usuario);
        if (await _userRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<User>(usuario);
        }

        Notificator.Handle("Não foi possível salvar usuário.");
        return null;
    }

    public async Task<User?> Alterar(int id, AlterarUsuarioDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("Os ids não conferem.");
            return null;
        }

        var usuario = await _userRepository.ObterPorId(id);
        if (usuario == null)
        {
            Notificator.HandleNotFoundResource();
            return null;
        }

        Mapper.Map(dto, usuario);
        if (!await Validar(usuario))
        {
            return null;
        }

        _userRepository.Alterar(usuario);
        if (await _userRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<User>(usuario);
        }

        Notificator.Handle("Não foi possível alterar usuário.");
        return null;
    }
    
    private async Task<bool> Validar(User usuario)
    {
        if (!usuario.Validar(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
        }
        
        return !Notificator.HasNotification;
    }
}