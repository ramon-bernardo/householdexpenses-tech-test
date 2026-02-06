using FluentValidation;
using HouseholdExpenses.Application.Person.Commands;

namespace HouseholdExpenses.Application.Person.Validators;

public sealed class CreatePeopleCommandValidator : AbstractValidator<CreatePeopleCommand>
{
    public CreatePeopleCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}
