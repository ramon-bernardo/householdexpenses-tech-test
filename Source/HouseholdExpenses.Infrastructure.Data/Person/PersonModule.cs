using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HouseholdExpenses.Application.Person.Repositories;
using HouseholdExpenses.Infrastructure.Data.Person.Repositories;

namespace HouseholdExpenses.Infrastructure.Data.Person;

public static class PersonModule
{
    public static IServiceCollection AddPersonInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper((configuration) =>
        {
            configuration.AddProfile<PersonProfile>();
        });

        services.AddScoped<IPeopleRepository, PeopleRepository>();

        return services;
    }
}
