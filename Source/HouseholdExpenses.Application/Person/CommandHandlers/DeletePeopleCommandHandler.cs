using MediatR;
using HouseholdExpenses.Application.Person.Commands;
using HouseholdExpenses.Application.Person.Repositories;

namespace HouseholdExpenses.Application.Person.CommandHandlers;

public sealed class DeletePeopleCommandHandler(
    IPeopleRepository peopleRepository
) : IRequestHandler<DeletePeopleCommand, Unit>
{
    private readonly IPeopleRepository PeopleRepository = peopleRepository;

    public async Task<Unit> Handle(DeletePeopleCommand request, CancellationToken cancellationToken)
    {
        var people = await PeopleRepository.GetActiveById(request.Id);
        if (people is null)
        {
            throw new Exception("Person not found."); // NotFoundException
        }

        people.Delete();

        await PeopleRepository.Update(people);

        return Unit.Value;
    }
}
