using System.ComponentModel.DataAnnotations;
using CycleTracker.Application.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;

namespace CycleTracker.API.Controllers;

public abstract class BaseController : ControllerBase
{
    private readonly INotificator _notificator;

    protected BaseController(INotificator notificator)
    {
        _notificator = notificator;
    }

    // Métodos de Resposta Customizada
    protected IActionResult NoContentResponse() 
        => CustomResponse(NoContent());

    protected IActionResult CreatedResponse(string uri = "", object? result = null) 
        => CustomResponse(Created(uri, result));

    protected IActionResult OkResponse(object? result = null) 
        => CustomResponse(Ok(result));

    // Custom Response com base nas notificações e estado da operação
    protected IActionResult CustomResponse(IActionResult result)
    {
        if (OperacaoValida)
            return result;

        if (_notificator.IsNotFoundResource)
            return NotFound();

        return BadRequest(new { errors = _notificator.GetNotifications().ToList() });
    }

    // Custom Response com base no ModelState
    protected IActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
        {
            var erros = modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            foreach (var erro in erros)
            {
                AdicionarErroProcessamento(erro);
            }
        }

        return CustomResponse(BadRequest(new { errors = _notificator.GetNotifications().ToList() }));
    }

    // Custom Response com base em FluentValidation
    protected IActionResult CustomResponse(FluentValidation.Results.ValidationResult validationResult)
    {
        foreach (var erro in validationResult.Errors)
        {
            AdicionarErroProcessamento(erro.ErrorMessage);
        }

        return CustomResponse(BadRequest(new { errors = _notificator.GetNotifications().ToList() }));
    }


    // Propriedade que verifica se a operação é válida (sem notificações ou erros)
    private bool OperacaoValida => !_notificator.HasNotification && !_notificator.IsNotFoundResource;

    // Método auxiliar para adicionar erros ao Notificator
    private void AdicionarErroProcessamento(string erro) 
        => _notificator.Handle(erro);
}