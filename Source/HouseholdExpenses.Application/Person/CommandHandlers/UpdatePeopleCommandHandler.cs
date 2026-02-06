using MediatR;
using AutoMapper;
using HouseholdExpenses.Application.Person.Commands;
using HouseholdExpenses.Application.Person.DTOs;
using HouseholdExpenses.Application.Person.Repositories;

namespace HouseholdExpenses.Application.Person.CommandHandlers;

public sealed class UpdatePeopleCommandHandler(
    IPeopleRepository peopleRepository,
    IMapper mapper
) : IRequestHandler<UpdatePeopleCommand, PeopleDTO>
{
    private readonly IPeopleRepository PeopleRepository = peopleRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<PeopleDTO> Handle(UpdatePeopleCommand request, CancellationToken cancellationToken)
    {
        var people = await PeopleRepository.GetActiveById(request.Id);
        if (people is null)
        {
            throw new Exception("Person not found."); // NotFoundException
        }

        people.Update(request.Name, request.Age);

        await PeopleRepository.Update(people);

        return Mapper.Map<PeopleDTO>(people);
    }
}
