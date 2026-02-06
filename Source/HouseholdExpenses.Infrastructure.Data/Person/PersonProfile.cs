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
            .ConstructUsing((dataModel, context) =>
            {
                return People.Create(dataModel.Name, dataModel.Age);
            });
    }
}
