using FluentValidation;
using HouseholdExpenses.Application.Person.Commands;

namespace HouseholdExpenses.Application.Person.Validators;

public sealed class UpdatePeopleCommandValidator : AbstractValidator<UpdatePeopleCommand>
{
    public UpdatePeopleCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}
