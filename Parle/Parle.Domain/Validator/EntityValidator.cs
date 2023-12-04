using FluentValidation;

namespace Parle.Domain.Validator;
//Generic Type: Placeholder for a var type
public abstract class EntityValidator<TEntity> : 
    AbstractValidator<TEntity>
    where TEntity : Entity 
{
    protected EntityValidator()
    {
        RuleFor(prop => prop.Id).NotEmpty()
            .NotNull()
            .Must(id => !id.Equals(Guid.Empty))
            .WithMessage("Invalid Id");
        
        //Revisit understanding
        RuleFor(prop => prop.Created)
            .NotEmpty()
            .NotNull()
            .WithMessage("Invalid Created");

    }
}