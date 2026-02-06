using MediatR;
using AutoMapper;
using HouseholdExpenses.Application.Person.DTOs;
using HouseholdExpenses.Application.Person.Queries;
using HouseholdExpenses.Application.Person.Repositories;

namespace HouseholdExpenses.Application.Person.QueryHandlers;

public sealed class GetPeopleByIdQueryHandler(
    IPeopleRepository peopleRepository,
    IMapper mapper
) : IRequestHandler<GetPeopleByIdQuery, PeopleDTO?>
{
    private readonly IPeopleRepository PeopleRepository = peopleRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<PeopleDTO?> Handle(GetPeopleByIdQuery request, CancellationToken cancellationToken)
    {
        var people = await PeopleRepository.GetActiveById(request.Id);
        var mappedPeople = Mapper.Map<PeopleDTO>(people);
        return mappedPeople;
    }
}
