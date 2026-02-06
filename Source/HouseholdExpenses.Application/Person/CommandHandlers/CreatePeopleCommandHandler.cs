using MediatR;
using AutoMapper;
using HouseholdExpenses.Application.Person.Commands;
using HouseholdExpenses.Application.Person.DTOs;
using HouseholdExpenses.Application.Person.Repositories;
using HouseholdExpenses.Domain.Person.Entities;

namespace HouseholdExpenses.Application.Person.CommandHandlers;

public sealed class CreatePeopleCommandHandler(
    IPeopleRepository peopleRepository,
    IMapper mapper
) : IRequestHandler<CreatePeopleCommand, PeopleDTO>
{
    private readonly IPeopleRepository PeopleRepository = peopleRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<PeopleDTO> Handle(CreatePeopleCommand request, CancellationToken cancellationToken)
    {
        var people = People.Create(request.Name, request.Age);

        var persistedPeople = await PeopleRepository.Add(people);

        return Mapper.Map<PeopleDTO>(persistedPeople);
    }
}
