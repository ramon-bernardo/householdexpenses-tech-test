using HouseholdExpenses.Domain.Person.Entities;

namespace HouseholdExpenses.Application.Person.Repositories;

public interface IPeopleRepository
{
    Task<People?> GetActiveById(uint id);

    Task<IReadOnlyCollection<People>> GetAllActive();

    Task<People> Add(People people);

    Task Update(People people);
}
