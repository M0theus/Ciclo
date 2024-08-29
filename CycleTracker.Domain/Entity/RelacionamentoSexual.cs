using CycleTracker.Domain.Validation;
using FluentValidation.Results;

namespace CycleTracker.Domain.Entity;

public class RelacionamentoSexual : Entity
{
    public DateOnly Data { get; set; }
    public int CicloId { get; set; }

    public virtual Cycle Cicly { get; set; } = new Cycle();

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new RelacionamentoSexualValidator().Validate(this);
        return validationResult.IsValid;
    }
}