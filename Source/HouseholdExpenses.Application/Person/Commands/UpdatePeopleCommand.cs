using MediatR;
using HouseholdExpenses.Application.Person.DTOs;

namespace HouseholdExpenses.Application.Person.Commands;

public sealed record UpdatePeopleCommand(
    uint Id,
    string Name,
    uint Age
) : IRequest<PeopleDTO>
{ }
