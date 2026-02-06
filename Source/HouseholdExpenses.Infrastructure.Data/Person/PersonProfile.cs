using AutoMapper;
using HouseholdExpenses.Domain.Person.Entities;
using HouseholdExpenses.Infrastructure.Data.Person.Models;

namespace HouseholdExpenses.Infrastructure.Data.Person;

public sealed class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<People, PeopleModel>();
        CreateMap<PeopleModel, People>()
            .ConstructUsing((model, context) =>
            {
                return People.Create(model.Name, model.Age);
            });
    }
}
