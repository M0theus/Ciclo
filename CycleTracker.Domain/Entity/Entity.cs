using CycleTracker.Domain.Contracts;
using FluentValidation.Results;

namespace CycleTracker.Domain.Entity;

public abstract class Entity : BaseEntity
{
    public virtual bool Validar(out ValidationResult validationResult)
    {
        validationResult = new ValidationResult();
        return validationResult.IsValid;
    }
}

public abstract class EntityNotTracked : BaseEntity
{
}

public abstract class BaseEntity : IEntity
{
    public int Id { get; set; }
}