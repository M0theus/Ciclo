using CycleTracker.Application.Contracts.Services;
using CycleTracker.Application.Dto.V1.User;
using CycleTracker.Application.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CycleTracker.API.Controllers.V1.User;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : MainController
{
    private readonly IUserService _usuarioService;
    
    public UsuarioController(INotificator notificator, IUserService usuarioService) : base(notificator)
    { ;
        _usuarioService = usuarioService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromForm] CadastrarUsuarioDto dto)
    {
        var usuario = await _usuarioService.Cadastrar(dto);
        return CreatedResponse("", usuario);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Alterar(int id, [FromForm] AlterarUsuarioDto dto)
    {
        var usuario = await _usuarioService.Alterar(id, dto);
        return OkResponse(usuario);
    }
}