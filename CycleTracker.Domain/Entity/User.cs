using CycleTracker.Domain.Validation;
using FluentValidation.Results;

namespace CycleTracker.Domain.Entity;

public class User : Entity
{
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public string? Apelido { get; set; }

    public virtual Cycle Ciclo { get; set; } = new();

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new UserValidator().Validate(this);
        return validationResult.IsValid;
    }
}