using FluentValidation;
using HouseholdExpenses.Application.Person.Commands;

namespace HouseholdExpenses.Application.Person.Validators;

public sealed class DeletePeopleCommandValidator : AbstractValidator<DeletePeopleCommand>
{
    public DeletePeopleCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
