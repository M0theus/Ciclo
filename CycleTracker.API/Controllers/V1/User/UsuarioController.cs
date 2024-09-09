using CycleTracker.Application.Contracts.Services;
using CycleTracker.Application.Dto.V1.User;
using CycleTracker.Application.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CycleTracker.API.Controllers.V1.User;

public class UsuarioController : MainController
{
    private readonly IMediator _mediator;
    private readonly IUserService _usuarioService;
    
    protected UsuarioController(INotificator notificator, IMediator mediator, IUserService usuarioService) : base(notificator)
    {
        _mediator = mediator;
        _usuarioService = usuarioService;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Cadastrar([FromForm] CadastrarUsuarioDto dto)
    {
        var usuario = await _usuarioService.Cadastrar(dto);
        return CreatedResponse("", usuario);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Alterar(int id, [FromForm] AlterarUsuarioDto dto)
    {
        var usuario = await _usuarioService.Alterar(id, dto);
        return OkResponse(usuario);
    }
}