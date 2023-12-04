using FluentValidation;

namespace Parle.Domain.Validator;

public class MenuItemValidator : EntityValidator<MenuItem>
{
    public MenuItemValidator()
    {
        RuleFor(prop => prop.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Invalid Name");
    }
}