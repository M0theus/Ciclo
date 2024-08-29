using CycleTracker.Domain.Entity;
using FluentValidation;

namespace CycleTracker.Domain.Validation;

public class RelacionamentoSexualValidator : AbstractValidator<RelacionamentoSexual>
{
    public RelacionamentoSexualValidator()
    {
        RuleFor(c => c.Data)
            .NotEmpty();
    }
}