using AutoMapper;
using HouseholdExpenses.Application.Person.DTOs;
using HouseholdExpenses.Domain.Person.Entities;

namespace HouseholdExpenses.Application.Person;

public sealed class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<People, PeopleDTO>();
    }
}
