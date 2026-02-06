using FluentValidation;
using HouseholdExpenses.Application.Person.Commands;

namespace HouseholdExpenses.Application.Person.Validators;

public sealed class UpdatePeopleCommandValidator : AbstractValidator<UpdatePeopleCommand>
{
    public UpdatePeopleCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0u)
            .WithMessage("Id must be greater than 0.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200).WithMessage("Name max length is 200.");
    }
}
