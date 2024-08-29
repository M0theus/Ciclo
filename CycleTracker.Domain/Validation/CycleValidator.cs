using CycleTracker.Domain.Entity;
using FluentValidation;

namespace CycleTracker.Domain.Validation;

public class CycleValidator : AbstractValidator<Cycle>
{
    public CycleValidator()
    {
        RuleFor(c => c.DataInicio)
            .NotEmpty();

        RuleFor(c => c.DuracaoCiclo)
            .NotEmpty();

        RuleFor(c => c.DataInicioUltimoCiclo)
            .NotEmpty();

        RuleFor(c => c.DuracaoMenstrual)
            .NotEmpty();
    }
}