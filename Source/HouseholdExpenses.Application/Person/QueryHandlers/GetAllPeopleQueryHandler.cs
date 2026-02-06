using MediatR;
using AutoMapper;
using HouseholdExpenses.Application.Person.DTOs;
using HouseholdExpenses.Application.Person.Queries;
using HouseholdExpenses.Application.Person.Repositories;

namespace HouseholdExpenses.Application.Person.QueryHandlers;

public sealed class GetAllPeopleQueryHandler(
    IPeopleRepository peopleRepository,
    IMapper mapper
) : IRequestHandler<GetAllPeopleQuery, IEnumerable<PeopleDTO>>
{
    private readonly IPeopleRepository PeopleRepository = peopleRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<IEnumerable<PeopleDTO>> Handle(GetAllPeopleQuery request, CancellationToken cancellationToken)
    {
        var peoples = await PeopleRepository.GetAllActive();
        var mappedPeoples = Mapper.Map<IEnumerable<PeopleDTO>>(peoples);
        return mappedPeoples;
    }
}
