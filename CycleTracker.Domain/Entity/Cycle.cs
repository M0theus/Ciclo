using CycleTracker.Domain.Validation;
using FluentValidation.Results;

namespace CycleTracker.Domain.Entity;

public class Cycle : Entity
{
    public DateOnly DataInicio { get; set; }
    public int DuracaoCiclo { get; set; }
    public int DuracaoMenstrual { get; set; }
    public DateOnly DataInicioUltimoCiclo { get; set; }
    public int UsuarioId { get; set; }

    public virtual User User { get; set; } = new();
    public virtual List<RelacionamentoSexual> RelacionamentoSexuals { get; set; } = new();

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new CycleValidator().Validate(this);
        return validationResult.IsValid;
    }
}