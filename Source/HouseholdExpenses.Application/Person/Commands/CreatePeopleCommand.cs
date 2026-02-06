using MediatR;
using HouseholdExpenses.Application.Person.DTOs;

namespace HouseholdExpenses.Application.Person.Commands;

public sealed record CreatePeopleCommand(
    string Name,
    uint Age
) : IRequest<PeopleDTO>
{ }
