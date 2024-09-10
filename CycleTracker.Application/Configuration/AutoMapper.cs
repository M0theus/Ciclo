using AutoMapper;
using CycleTracker.Application.Dto.V1.User;
using CycleTracker.Domain.Entity;

namespace CycleTracker.Application.Configuration;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<User, UsuarioDto>();
        CreateMap<UsuarioDto, User>();

        CreateMap<User, CadastrarUsuarioDto>();
        CreateMap<CadastrarUsuarioDto, User>()
            .ForMember(dest => dest.Ciclo, opt => opt.Ignore());

        CreateMap<UsuarioDto, AlterarUsuarioDto>();
        CreateMap<AlterarUsuarioDto, UsuarioDto>();
    }
}