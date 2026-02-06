using MediatR;

namespace HouseholdExpenses.Application.Person.Commands;

public sealed record DeletePeopleCommand(uint Id) : IRequest<Unit> { }
