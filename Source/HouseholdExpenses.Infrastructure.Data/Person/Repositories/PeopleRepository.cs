using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HouseholdExpenses.Application.Person.Repositories;
using HouseholdExpenses.Domain.Person.Entities;
using HouseholdExpenses.Infrastructure.Data.Common;
using HouseholdExpenses.Infrastructure.Data.Person.Models;

namespace HouseholdExpenses.Infrastructure.Data.Person.Repositories;

public sealed class PeopleRepository(
    SqliteDbContext dbContext,
    IMapper mapper
) : IPeopleRepository
{
    private readonly SqliteDbContext DbContext = dbContext;
    private readonly IMapper Mapper = mapper;

    public async Task<People> Add(People people)
    {
        var peopleModel = Mapper.Map<PeopleModel>(people);
        await DbContext.AddAsync(peopleModel);
        await DbContext.SaveChangesAsync();
        return Mapper.Map<People>(peopleModel);
    }

    public Task Update(People people)
    {
        var peopleModel = Mapper.Map<PeopleModel>(people);
        DbContext.Update(peopleModel);
        return Task.CompletedTask;
    }

    public async Task<People?> GetActiveById(uint id)
    {
        var peopleModel = await DbContext.Peoples
            .Where((people) => people.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return Mapper.Map<People>(peopleModel);
    }

    public async Task<IReadOnlyCollection<People>> GetAllActive()
    {
        var peopleModels = await DbContext.Peoples
            .AsNoTracking()
            .ToListAsync();

        return Mapper.Map<IReadOnlyCollection<People>>(peopleModels);
    }
}
