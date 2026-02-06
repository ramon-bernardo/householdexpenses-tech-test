using MediatR;
using HouseholdExpenses.Application.Person.DTOs;

namespace HouseholdExpenses.Application.Person.Queries;

public sealed record GetAllPeopleQuery : IRequest<IEnumerable<PeopleDTO>> { }
